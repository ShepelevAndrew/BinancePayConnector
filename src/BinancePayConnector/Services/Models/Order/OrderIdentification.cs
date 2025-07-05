using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;

namespace BinancePayConnector.Services.Models.Order;

public record OrderIdentification(
    Env Env,
    string MerchantTradeNo,
    string? AppId = null
);