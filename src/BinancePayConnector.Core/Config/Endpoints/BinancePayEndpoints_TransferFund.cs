namespace BinancePayConnector.Core.Config.Endpoints;

public static partial class BinancePayEndpoints
{
    public static class TransferFund
    {
        public const string TransferFundUri = CommonUri + "/wallet/transfer";
        public const string QueryTransferResult = CommonUri + "/wallet/transfer/query";
    }
}
