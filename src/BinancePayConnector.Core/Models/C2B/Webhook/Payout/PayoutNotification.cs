using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutQuery.Enums;

namespace BinancePayConnector.Core.Models.C2B.Webhook.Payout;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/webhook-payout#transferqueryresult"/>.
/// </summary>
/// <param name="RequestId">The passed-in request id.</param>
/// <param name="BatchStatus">Enum values from <see cref="RestApi.Payout.PayoutQuery.Enums.BatchStatus"/>.</param>
/// <param name="Currency">The request currency. Enum values from <see cref="Assets"/>.</param>
/// <param name="TotalAmount">Total transfer amount in this batch.</param>
/// <param name="TotalNumber">Total number of transfers in the batch.</param>
public sealed record PayoutNotification(
    string RequestId,
    string BatchStatus,
    long MerchantId,
    string Currency,
    decimal TotalAmount,
    int TotalNumber
);
