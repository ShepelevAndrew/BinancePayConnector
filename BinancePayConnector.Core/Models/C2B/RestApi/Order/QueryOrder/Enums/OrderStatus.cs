namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.QueryOrder.Enums;

public static class OrderStatus
{
    public const string Initial = "INITIAL";
    public const string Pending = "PENDING";
    public const string Paid = "PAID";
    public const string Canceled = "CANCELED";
    public const string Error = "ERROR";
    public const string Refunding = "REFUNDING";
    public const string Refunded = "REFUNDED";
    public const string FullRefunded = "FULL_REFUNDED";
    public const string Expired = "EXPIRED";
}
