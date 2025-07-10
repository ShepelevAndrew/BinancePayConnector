using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.PaymentNotification;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.DirectDebit;

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
