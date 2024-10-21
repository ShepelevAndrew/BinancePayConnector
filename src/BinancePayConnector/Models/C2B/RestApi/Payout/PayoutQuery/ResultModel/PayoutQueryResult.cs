using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery.ResultModel;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-payout-query#transferqueryresult"/>.
/// </summary>
/// <param name="BatchStatus">Enum values from: <see cref="Enums.BatchStatus"/>.</param>
/// <param name="TotalAmount">Total transfer amount in this batch.</param>
/// <param name="TotalNumber">Total number of transfers in the batch.</param>
public sealed record PayoutQueryResult(
    string RequestId,
    string BatchStatus,
    long MerchantId,
    string Currency,
    decimal TotalAmount,
    int TotalNumber,
    IEnumerable<TransferDetailResult> TransferDetailList
);
