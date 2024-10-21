namespace BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;

public sealed record GoodsUnitAmount(
    string Currency,
    decimal Amount
);
