using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Clients.WebHookListener;
using BinancePayConnector.Core.Config.Options;
using BinancePayConnector.Core.Models.Abstractions;
using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.C2B.Webhook.Common;
using BinancePayConnectorSlim.Helpers;

namespace BinancePayConnectorSlim;

public class BinancePaySlim : IBinancePaySlim
{
    private readonly IBinancePayClient _binancePayClient;
    private readonly BinancePayReceiver? _binancePayReceiver;
    private readonly BinancePayWebhookConfig? _webhookConfig;

    public BinancePaySlim(
        string apiKey,
        string apiSecret)
    {
        _binancePayClient = new BinancePayClient(apiKey, apiSecret);
    }

    public BinancePaySlim(
        IBinancePayClient binancePayClient)
    {
        _binancePayClient = binancePayClient;
    }

    public BinancePayWebhookConfig? WebhookConfig
    {
        get => _webhookConfig;
        init
        {
            if (_webhookConfig != null)
                throw new InvalidOperationException("WebhookConfig is already set.");

            _webhookConfig = value ?? throw new ArgumentNullException(nameof(value));
            _binancePayReceiver = new BinancePayReceiver(_webhookConfig);
        }
    }

    // TODO: Added caching for getting methods by reflection. (optimize speed and memory allocation)
    public async Task<BinancePayResult<TResponse>> Send<TResponse>(
        IRequest<TResponse> request,
        CancellationToken ct = default)
    {
        var handlerType = ReflectionHelper.GetHandlerType<TResponse>();
        var handler = handlerType.CreateHandler(_binancePayClient);

        var method = ReflectionHelper.GetHandlerExecuteMethod(request);
        return await ReflectionHelper.InvokeHandler(handler, method, request, ct);
    }

    public void OnUpdateInvoke(Action<WebHookRequest> callback)
    {
        _binancePayReceiver?.OnUpdateInvoke(callback);
    }

    public void OnUpdateInvoke(Action<WebHookRequest> callback, string name)
    {
        _binancePayReceiver?.OnUpdateInvoke(callback, name);
    }

    public void OnUpdateInvoke(Func<WebHookRequest, ResponseType> callback, string name)
    {
        _binancePayReceiver?.OnUpdateInvoke(callback, name);
    }

    public async Task StopReceiving()
    {
        if(_binancePayReceiver is not null)
            await _binancePayReceiver.StopReceiving();
    }
}