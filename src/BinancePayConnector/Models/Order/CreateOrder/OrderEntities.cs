using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.BuyerModel;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.ShippingModel;

namespace BinancePayConnector.Models.Order.CreateOrder;

public record OrderEntities(
    Merchant? Merchant = null,
    Shipping? Shipping = null,
    Buyer? Buyer = null
);