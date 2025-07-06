using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.SubmitSplit;

namespace BinancePayConnector.MediatrStyle.Handlers.ProfitSharing;

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