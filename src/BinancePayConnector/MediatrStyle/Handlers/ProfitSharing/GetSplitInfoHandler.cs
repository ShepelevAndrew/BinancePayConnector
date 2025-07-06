using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.SplitReturn;

namespace BinancePayConnector.MediatrStyle.Handlers.ProfitSharing;

public class GetSplitInfoHandler(
    IBinancePayClient client
) : IRequestHandler<SplitReturnRequest, SplitReturnResult>
{
    public async Task<BinancePayResult<SplitReturnResult>> ExecuteAsync(
        SplitReturnRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<SplitReturnResult, SplitReturnRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.SplitReturn,
            content: command,
            ct: ct);

        return response;
    }
}