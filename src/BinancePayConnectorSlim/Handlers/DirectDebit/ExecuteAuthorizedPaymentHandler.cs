using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.Payment;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.DirectDebit;

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
