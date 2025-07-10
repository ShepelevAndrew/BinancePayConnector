using BinancePayConnector.Core.Models.C2B.RestApi.Payout.BatchPayout.Enums;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Payout.BatchPayout;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-payout#payouttransferresponse"/>.
/// </summary>
/// <param name="RequestId">The passed-in request ID.No special characters allowed, only numbers and alphabet.</param>
/// <param name="Status">Enum values from: <see cref="PayoutStatus"/>.</param>
public sealed record BatchPayoutResult(
    string RequestId,
    string Status
);