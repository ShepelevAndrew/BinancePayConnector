using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.QuerySplit.Enums;

namespace BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.QuerySplit;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-query-split#response"/>.
/// </summary>
/// <param name="Status">You can convert int to enum value: <see cref="QuerySplitStatus"/>.</param>
public sealed record QuerySplitResult(
    string SplitOrderNo,
    string MerchantRequestId,
    string PrepayOrderId,
    int Status,
    IEnumerable<SplitReceiverOrderDetail> ReceiverOrderDetails
);
