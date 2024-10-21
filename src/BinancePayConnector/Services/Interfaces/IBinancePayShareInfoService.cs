using BinancePayConnector.Models.C2B.RestApi.ShareInfo.ShareAccoutId;
using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayShareInfoService
{
    Task<BinancePayResult<ShareAccountIdResult>> ShareAccountId(
        ShareAccountId request,
        CancellationToken ct = default);
}
