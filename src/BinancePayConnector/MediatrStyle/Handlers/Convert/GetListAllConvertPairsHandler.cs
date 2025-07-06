using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Convert.ListAllConvertPairs;

namespace BinancePayConnector.MediatrStyle.Handlers.Convert;

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
