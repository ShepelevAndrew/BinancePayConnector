using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.SplitReturn.Enums;

namespace BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.SplitReturn;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-split-return#response"/>.
/// </summary>
/// <param name="Status">You can convert int to enum value: <see cref="SplitReturnStatus"/>.</param>
/// <param name="FinishTime">Unix_timestamp (seconds).</param>
public sealed record SplitReturnResult(
    string PrepayOrderId,
    string SplitOrderNo,
    string OriginMerchantRequestId,
    string MerchantReturnNo,
    string TransferOutAccount,
    decimal ReturnAmount,
    string ReturnOrderNo,
    int Status,
    string? FailReason,
    long FinishTime
);
