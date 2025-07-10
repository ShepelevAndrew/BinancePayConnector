namespace BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.SubmitSplit;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-submit-split#response"/>.
/// </summary>
public record SubmitSplitResult(
    string SplitOrderNo,
    string MerchantRequestId,
    string PrepayOrderId,
    int Status,
    IEnumerable<SplitReceiverOrderDetail> ReceiverOrderDetails
);
