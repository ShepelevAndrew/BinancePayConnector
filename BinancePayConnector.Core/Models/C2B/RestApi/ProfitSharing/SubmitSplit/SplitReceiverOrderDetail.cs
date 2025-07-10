namespace BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.SubmitSplit;

public record SplitReceiverOrderDetail(
    string Account,
    decimal Amount,
    string DetailId,
    int Status,
    long FinishTime,
    string? FailReason = null
);
