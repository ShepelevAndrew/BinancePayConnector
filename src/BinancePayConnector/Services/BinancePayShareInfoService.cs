using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.ShareInfo.ShareAccoutId;
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
