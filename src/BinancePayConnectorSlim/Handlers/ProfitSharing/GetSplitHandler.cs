using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.QuerySplit;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.ProfitSharing;

public class GetSplitHandler(
    IBinancePayClient client
) : IRequestHandler<QuerySplitRequest, QuerySplitResult>
{
    public async Task<BinancePayResult<QuerySplitResult>> ExecuteAsync(
        QuerySplitRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QuerySplitResult, QuerySplitRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.QuerySplit,
            content: command,
            ct: ct);

        return response;
    }
}