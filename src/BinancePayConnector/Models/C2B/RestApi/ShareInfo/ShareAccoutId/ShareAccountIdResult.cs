namespace BinancePayConnector.Models.C2B.RestApi.ShareInfo.ShareAccoutId;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-shareinfo-account-id#dataobject"/>.
/// </summary>
public sealed record ShareAccountIdResult(
    long MerchantId,
    string Id,
    string RequestId,
    long ExpireTime,
    string QrcodeContent,
    string QrcodeUrl
);
