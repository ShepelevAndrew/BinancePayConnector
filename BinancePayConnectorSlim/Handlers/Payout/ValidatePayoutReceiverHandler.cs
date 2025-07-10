using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutValidateReceiver;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Payout;

public class ValidatePayoutReceiverHandler(
    IBinancePayClient client
) : IRequestHandler<PayoutValidateReceiverRequest, bool?>
{
    public async Task<BinancePayResult<bool?>> ExecuteAsync(
        PayoutValidateReceiverRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<bool?, PayoutValidateReceiverRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Payout.ValidateReceiver,
            content: command,
            ct: ct);

        return response;
    }
}
