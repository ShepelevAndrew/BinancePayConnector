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
        string requestId,
        string? subMerchantId = null,
        string? webhookUrl = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<ShareAccountIdResult, ShareAccountIdRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ShareInfo.ShareAccountId,
            content: new ShareAccountIdRequest(requestId, subMerchantId, webhookUrl),
            ct: ct);

        return response;
    }
}
