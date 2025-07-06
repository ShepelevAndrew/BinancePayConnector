namespace BinancePayConnector.Services.Models.Payout.ExecuteBatchPayout;

public sealed record PayoutIdentification(
    string RequestId,
    string BatchName
);