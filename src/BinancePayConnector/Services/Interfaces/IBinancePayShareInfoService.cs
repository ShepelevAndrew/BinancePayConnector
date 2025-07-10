using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Models.C2B.RestApi.ShareInfo.ShareAccoutId;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayShareInfoService
{
    Task<BinancePayResult<ShareAccountIdResult>> ShareAccountId(
        string requestId,
        string? subMerchantId = null,
        string? webhookUrl = null,
        CancellationToken ct = default);
}
