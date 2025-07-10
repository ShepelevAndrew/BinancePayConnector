namespace BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.QuerySplit;

public sealed record SplitReceiverOrderDetail(
    string Account,
    decimal Amount,
    string FailReason,
    string DetailId,
    int Status,
    long FinishTime
);
