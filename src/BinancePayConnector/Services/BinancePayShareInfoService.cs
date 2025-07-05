using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.ShareInfo.ShareAccoutId;
using BinancePayConnector.Services.Interfaces;

namespace BinancePayConnector.Services;

public class BinancePayShareInfoService(
    IBinancePayClient client
) : IBinancePayShareInfoService
{
    public async Task<BinancePayResult<ShareAccountIdResult>> ShareAccountId(
        ShareAccountId request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<ShareAccountIdResult, ShareAccountId>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ShareInfo.ShareAccountId,
            content: request,
            ct: ct);

        return response;
    }
}
