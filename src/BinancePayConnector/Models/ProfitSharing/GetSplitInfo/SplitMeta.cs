namespace BinancePayConnector.Models.ProfitSharing.GetSplitInfo;

public sealed record SplitMeta(
    string? SplitOrderNo = null,
    string? OriginMerchantRequestId = null,
    string? Description = null,
    string? WebhookUrl = null
);