using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.Webhook.Common;

namespace BinancePayConnector.Clients.WebHookListener;

public interface IBinancePayReceiver
{
    void OnUpdateInvoke(Action<WebHookRequest> callback);

    void OnUpdateInvoke(Action<WebHookRequest> callback, string name);

    void OnUpdateInvoke(Func<WebHookRequest, ResponseType> callback, string name);

    // There is no reason create Func<WebHookRequest, ResponseType> callback without string name,
    // because it will not be match, and if you will have more than one method, it returns only
    // last result.
    // public void OnUpdateInvoke(Func<WebHookRequest, ResponseType> callback);

    Task StopReceiving();
}