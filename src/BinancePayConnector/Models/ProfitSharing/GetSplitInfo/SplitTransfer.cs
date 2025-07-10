namespace BinancePayConnector.Models.ProfitSharing.GetSplitInfo;

public sealed record SplitTransfer(
    string TransferOutAccount,
    decimal ReturnAmount
);