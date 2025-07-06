using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutValidateReceiver;

namespace BinancePayConnector.MediatrStyle.Handlers.Payout;

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
