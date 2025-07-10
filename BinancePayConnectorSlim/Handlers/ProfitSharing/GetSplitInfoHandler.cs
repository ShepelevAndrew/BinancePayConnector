using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.SplitReturn;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.ProfitSharing;

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