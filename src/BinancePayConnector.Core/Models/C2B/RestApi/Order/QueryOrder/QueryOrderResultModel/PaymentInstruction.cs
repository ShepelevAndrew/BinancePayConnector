namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;

public sealed record PaymentInstruction(
    string Currency,
    string Amount,
    string Price
);
