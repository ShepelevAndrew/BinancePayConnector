namespace BinancePayConnector.Core.Config.Endpoints;

public static partial class BinancePayEndpoints
{
    public static class Order
    {
        public const string CreateOrder = CommonUri + "/v3/order";
        public const string QueryOrder = CommonUri + "/v2/order/query";
        public const string CloseOrder = CommonUri + "/order/close";
        public const string RefundOrder = CommonUri + "/order/refund";
        public const string QueryRefund = CommonUri + "/order/refund/query";
        public const string PaymentPayerVerification = CommonUri + "/order/payer/verification";
    }
}
