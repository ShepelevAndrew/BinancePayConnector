using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.PaymentNotification;

namespace BinancePayConnector.MediatrStyle.Handlers.DirectDebit;

public class NotifyPaymentHandler(
    IBinancePayClient client
) : IRequestHandler<PaymentNotificationRequest, PaymentNotificationResult>
{
    public async Task<BinancePayResult<PaymentNotificationResult>> ExecuteAsync(
        PaymentNotificationRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<PaymentNotificationResult, PaymentNotificationRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.PaymentNotification,
            content: command,
            ct: ct);

        return response;
    }
}
