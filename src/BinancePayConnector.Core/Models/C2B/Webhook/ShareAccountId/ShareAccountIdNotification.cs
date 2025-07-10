namespace BinancePayConnector.Core.Models.C2B.Webhook.ShareAccountId;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/webhook-shareinfo-account-id#notification-data"/>.
/// </summary>
/// <param name="RequestId">The unique ID assigned by the merchant to identify a share account id request.</param>
public record ShareAccountIdNotification(
    string RequestId,
    string UserBinanceId,
    string? UserName = null
);
