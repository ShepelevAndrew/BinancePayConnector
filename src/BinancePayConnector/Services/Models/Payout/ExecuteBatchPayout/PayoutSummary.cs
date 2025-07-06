namespace BinancePayConnector.Services.Models.Payout.ExecuteBatchPayout;

public sealed record PayoutSummary(
    string Currency,
    decimal TotalAmount,
    int TotalNumber
);