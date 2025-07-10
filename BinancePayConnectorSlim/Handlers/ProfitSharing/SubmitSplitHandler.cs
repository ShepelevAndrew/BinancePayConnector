using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.SubmitSplit;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.ProfitSharing;

public class SubmitSplitHandler(
    IBinancePayClient client
) : IRequestHandler<SubmitSplitRequest, SubmitSplitResult>
{
    public async Task<BinancePayResult<SubmitSplitResult>> ExecuteAsync(
        SubmitSplitRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<SubmitSplitResult, SubmitSplitRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.SubmitSplit,
            content: command,
            ct: ct);

        return response;
    }
}