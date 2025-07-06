using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Order.PaymentPayerVerification;

namespace BinancePayConnector.MediatrStyle.Handlers.Order;

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