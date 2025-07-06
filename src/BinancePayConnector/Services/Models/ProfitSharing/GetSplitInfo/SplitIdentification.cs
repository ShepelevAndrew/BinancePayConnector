namespace BinancePayConnector.Services.Models.ProfitSharing.GetSplitInfo;

public sealed record SplitIdentification(
    string PrepayOrderId,
    string MerchantReturnNo
);