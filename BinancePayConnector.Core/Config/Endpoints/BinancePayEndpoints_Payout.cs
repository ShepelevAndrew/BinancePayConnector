namespace BinancePayConnector.Core.Config.Endpoints;

public static partial class BinancePayEndpoints
{
    public static class Payout
    {
        public const string BatchPayout = CommonUri + "/payout/transfer";
        public const string ValidateReceiver = CommonUri + "/payout/receiver/check";
        public const string PayoutQuery = CommonUri + "/payout/query";
    }
}
