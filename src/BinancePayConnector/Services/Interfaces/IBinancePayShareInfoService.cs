using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.ShareInfo.ShareAccoutId;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayShareInfoService
{
    Task<BinancePayResult<ShareAccountIdResult>> ShareAccountId(
        string requestId,
        string? subMerchantId = null,
        string? webhookUrl = null,
        CancellationToken ct = default);
}
