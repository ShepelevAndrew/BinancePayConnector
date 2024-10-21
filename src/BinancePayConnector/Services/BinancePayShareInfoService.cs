using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.ShareInfo.ShareAccoutId;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Services.Models.Result;
using BinancePayConnector.Services.Extensions;

namespace BinancePayConnector.Services;

public class BinancePayShareInfoService(
    IBinancePayClient client)
        : IBinancePayShareInfoService
{
    public async Task<BinancePayResult<ShareAccountIdResult>> ShareAccountId(
        ShareAccountId request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<ShareAccountIdResult, ShareAccountId>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.ShareInfo.ShareAccountId,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<ShareAccountIdResult>();
        }
    }
}
