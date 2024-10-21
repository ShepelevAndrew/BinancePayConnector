namespace BinancePayConnector.Config.Endpoints;

public static partial class BinancePayEndpoints
{
    public static class DirectDebit
    {
        public const string CreateContract = CommonUri + "/direct-debit/contract";
        public const string QueryContract = CommonUri + "/direct-debit/contract/query";
        public const string TerminateContract = CommonUri + "/direct-debit/contract/termination";
        public const string PaymentNotification = CommonUri + "/pay/notify";
        public const string Payment = CommonUri + "/pay/apply";
    }
}
