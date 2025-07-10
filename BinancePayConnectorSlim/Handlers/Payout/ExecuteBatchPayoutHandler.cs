using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.BatchPayout;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Payout;

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
