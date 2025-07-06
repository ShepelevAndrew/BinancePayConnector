using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.QuerySplit;

namespace BinancePayConnector.MediatrStyle.Handlers.ProfitSharing;

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