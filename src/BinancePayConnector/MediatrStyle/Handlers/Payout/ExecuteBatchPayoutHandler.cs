using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Payout.BatchPayout;

namespace BinancePayConnector.MediatrStyle.Handlers.Payout;

public class ExecuteBatchPayoutHandler(
    IBinancePayClient client
) : IRequestHandler<BatchPayoutRequest, BatchPayoutResult>
{
    public async Task<BinancePayResult<BatchPayoutResult>> ExecuteAsync(
        BatchPayoutRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<BatchPayoutResult, BatchPayoutRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Payout.BatchPayout,
            content: command,
            ct: ct);

        return response;
    }
}
