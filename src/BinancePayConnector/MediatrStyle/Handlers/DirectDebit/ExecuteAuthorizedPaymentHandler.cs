using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.Payment;

namespace BinancePayConnector.MediatrStyle.Handlers.DirectDebit;

public class ExecuteAuthorizedPaymentHandler(
    IBinancePayClient client
) : IRequestHandler<PaymentRequest, PaymentResult>
{
    public async Task<BinancePayResult<PaymentResult>> ExecuteAsync(
        PaymentRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<PaymentResult, PaymentRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.Payment,
            content: command,
            ct: ct);

        return response;
    }
}
