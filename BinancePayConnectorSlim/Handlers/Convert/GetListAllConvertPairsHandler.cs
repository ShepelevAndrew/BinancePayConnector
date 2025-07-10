using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.ListAllConvertPairs;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Convert;

public class GetListAllConvertPairsHandler(
    IBinancePayClient client
) : IRequestHandler<ListAllConvertPairsRequest, ListAllConvertPairsResult>
{
    public async Task<BinancePayResult<ListAllConvertPairsResult>> ExecuteAsync(
        ListAllConvertPairsRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<ListAllConvertPairsResult, ListAllConvertPairsRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.ListAllConvertPairs,
            content: command,
            ct: ct);

        return response;
    }
}
