using System.Net;
using BinancePayConnector.Clients.WebHookListener.Helpers;
using BinancePayConnector.Config.Options;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.Webhook.Common;

namespace BinancePayConnector.Clients.WebHookListener;

public class BinancePayReceiver : IBinancePayReceiver
{
    private readonly HttpListener _listener;
    private readonly CancellationToken _cToken;
    private readonly CancellationTokenSource _cts = new();

    private readonly Dictionary<string, WebhookEventHandler> _namedCallbacks = new();
    private readonly Dictionary<string, WebhookEventHandlerWithResponse> _namedCallbacksWithResponse = new();

    public BinancePayReceiver(BinancePayWebhookConfig config)
    {
        _cToken = _cts.Token;
        _listener = new HttpListener();

        var baseUri = ValidateBaseUri(config.BaseUri);
        _listener.Prefixes.Add(baseUri);
    }

    private event WebhookEventHandler? OnReceiveWebhookRequest;
    private delegate void WebhookEventHandler(WebHookRequest request);

    private delegate ResponseType WebhookEventHandlerWithResponse(WebHookRequest request);

    public void OnUpdateInvoke(Action<WebHookRequest> callback)
    {
        StartIfNotListening(_cToken);
        OnReceiveWebhookRequest += callback.Invoke;
    }

    public void OnUpdateInvoke(Action<WebHookRequest> callback, string name)
    {
        ValidateCallbackName(name);

        StartIfNotListening(_cToken);
        TryAdd(_namedCallbacks, name, callback.Invoke);
    }

    public void OnUpdateInvoke(Func<WebHookRequest, ResponseType> callback, string name)
    {
        ValidateCallbackName(name);

        StartIfNotListening(_cToken);
        TryAdd(_namedCallbacksWithResponse, name, callback.Invoke);
    }

    public async Task StopReceiving()
    {
        if (!_cts.IsCancellationRequested)
        {
            await _cts.CancelAsync();

            if (_listener.IsListening)
            {
                _listener.Stop();
                _listener.Close();
            }

            _cts.Dispose();
        }
    }

    private void StartIfNotListening(CancellationToken ct)
    {
        if (_listener.IsListening) return;

        _listener.Start();

        Task.Run(async () =>
        {
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    var context = await _listener.GetContextAsync();

                    await HandleRequest(context, _namedCallbacks, _namedCallbacksWithResponse, ct);
                }
                catch (HttpListenerException ex) when (ex.ErrorCode == 995) 
                {
                    Console.WriteLine("Listener stopped.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }, ct);
    }

    private async Task HandleRequest(
        HttpListenerContext context,
        Dictionary<string, WebhookEventHandler> callbacks,
        Dictionary<string, WebhookEventHandlerWithResponse> callbacksWithResponse,
        CancellationToken ct)
    {
        var request = await context.ReadWebHookRequest(ct);

        var requestPath = context.Request.RawUrl?.TrimStart('/');
        if (string.IsNullOrEmpty(requestPath))
        {
            OnReceiveWebhookRequest?.Invoke(request);
            return;
        }

        var isCallbackExist = callbacks.TryGetValue(requestPath, out var callback);
        if (isCallbackExist)
        {
            callback?.Invoke(request);
            await context.SendOkResponse(RequestStatus.Success, ct);
        }

        var isCallbackWithResponseExist = callbacksWithResponse.TryGetValue(requestPath, out var callbackWithResponse);
        if (isCallbackWithResponseExist)
        {
            var result = callbackWithResponse?.Invoke(request);
            var status = result switch
            {
                ResponseType.Success => RequestStatus.Success,
                ResponseType.Failure => RequestStatus.Fail,
                _ => throw new ArgumentOutOfRangeException()
            };

            await context.SendOkResponse(status, ct);
        }

        if (!isCallbackExist || !isCallbackWithResponseExist)
        {
            context.SendNotFoundResponse();
        }
    }

    private static string ValidateBaseUri(string name)
        => name[^1] is '/'
            ? name
            : name + '/';

    private static void ValidateCallbackName(string name)
    {
        if (name[0] is '/')
        {
            throw new ArgumentException("Callback name can't start with '/'.");
        }
    }

    private static void TryAdd<TKey, TValue>(
        Dictionary<TKey, TValue> callbacks,
        TKey key,
        TValue value)
        where TKey : notnull
    {
        var isAdded = callbacks.TryAdd(key, value);
        if (!isAdded)
        {
            throw new ArgumentException("Callback with name '" + key + "' already exists.");
        }
    }
}
