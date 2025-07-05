using System.Reflection;
using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Helpers;

internal static class ReflectionHelper
{
    /// <summary>
    /// Get handler type by command response.
    /// </summary>
    /// <typeparam name="TResponse">Generic type of response from command request.</typeparam>
    /// <returns>Returns type of handler.</returns>
    public static Type GetHandlerType<TResponse>()
    {
        var interfaceType = typeof(IRequestHandler<,>);
        var responseType = typeof(TResponse);
        var commandType = FindClassImplementingInterface<IRequest<TResponse>>()
            ?? throw new ArgumentException($"Cannot find class implementing {nameof(IRequest<TResponse>)}.");

        var handlerType = FindClassImplementingGenericInterface(interfaceType, commandType, responseType)
            ?? throw new ArgumentException("There is no handler for this request.");

        return handlerType;
    }

    /// <summary>
    /// Create handler.
    /// </summary>
    /// <param name="handlerType">Type of concrete handler.</param>
    /// <param name="binanceClient">Constructor param in each handler.</param>
    /// <returns>Returns concrete handler in object.</returns>
    public static object CreateHandler(this Type handlerType, IBinancePayClient binanceClient)
    {
        var handler = Activator.CreateInstance(handlerType, binanceClient);
        if (handler is null)
        {
            throw new ArgumentNullException(nameof(handler), "Handler instance could not be created.");
        }

        return handler;
    }

    /// <summary>
    /// Get handler method info for continue executing.
    /// </summary>
    /// <param name="request">ICommand request.</param>
    /// <typeparam name="TResponse">Generic type of response from command request.</typeparam>
    /// <returns>Returns method info for handler executing.</returns>
    public static MethodInfo GetHandlerExecuteMethod<TResponse>(IRequest<TResponse> request)
    {
        var methodName = nameof(IRequestHandler<IRequest<TResponse>, TResponse>.ExecuteAsync);
        var interfaceType = typeof(IRequestHandler<,>);
        var specificInterfaceType = interfaceType.MakeGenericType(request.GetType(), typeof(TResponse));

        var methodInfo = specificInterfaceType.GetMethod(methodName);
        if (methodInfo == null)
        {
            throw new InvalidOperationException($"Method {methodName} not found on {specificInterfaceType}.");
        }

        return methodInfo;
    }

    /// <summary>
    /// Invoke handler executing method.
    /// </summary>
    /// <param name="handler">Concrete handler in object.</param>
    /// <param name="methodInfo">Executing method info from handler.</param>
    /// <param name="request">Request which should be executing.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <typeparam name="TResponse">Generic type of response from command request.</typeparam>
    /// <returns>Returns handler result.</returns>
    public static async Task<BinancePayResult<TResponse>> InvokeHandler<TResponse>(
        object handler,
        MethodInfo methodInfo,
        IRequest<TResponse> request,
        CancellationToken ct)
    {
        var result = await (Task<BinancePayResult<TResponse>>)methodInfo.Invoke(handler, [request, ct])!;
        return result;
    }

    /// <summary>
    /// Finds class that implement a specific interface in the provided assemblies.
    /// </summary>
    private static Type? FindClassImplementingInterface<TInterface>()
    {
        var interfaceType = typeof(TInterface);
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        return assemblies
            .SelectMany(a => a.GetTypes())
            .SingleOrDefault(t => interfaceType.IsAssignableFrom(t) && 
                            t is { IsClass: true, IsAbstract: false });
    }

    /// <summary>
    /// Finds class which implements generic interface with two concrete types.
    /// </summary>
    /// <param name="genericInterface">Type of generic interface.</param>
    /// <param name="type1">First generic type.</param>
    /// <param name="type2">Second generic type.</param>
    /// <returns>Type of class which implements this generic interface.</returns>
    private static Type? FindClassImplementingGenericInterface(Type genericInterface, Type type1, Type type2)
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t =>
                t is { IsClass: true, IsAbstract: false } &&
                t.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == genericInterface &&
                    i.GenericTypeArguments.SequenceEqual([type1, type2])
                ));
    }
}