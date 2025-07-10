using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.PaymentPayerVerification;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Order;

public class GetPaymentPayerVerificationHandler(
    IBinancePayClient client
) : IRequestHandler<PaymentPayerVerificationRequest, bool?>
{
    public async Task<BinancePayResult<bool?>> ExecuteAsync(
        PaymentPayerVerificationRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<bool?, PaymentPayerVerificationRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.PaymentPayerVerification,
            content: command,
            ct: ct);

        return response;
    }
}