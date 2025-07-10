namespace BinancePayConnector.Models.Payout.ExecuteBatchPayout;

public sealed record PayoutSummary(
    string Currency,
    decimal TotalAmount,
    int TotalNumber
);