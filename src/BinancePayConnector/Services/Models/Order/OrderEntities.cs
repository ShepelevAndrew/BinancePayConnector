using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.BuyerModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ShippingModel;

namespace BinancePayConnector.Services.Models.Order;

public record OrderEntities(
    Merchant? Merchant = null,
    Shipping? Shipping = null,
    Buyer? Buyer = null
);