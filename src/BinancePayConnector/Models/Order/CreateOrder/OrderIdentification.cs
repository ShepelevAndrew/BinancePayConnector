using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder;

namespace BinancePayConnector.Models.Order.CreateOrder;

public record OrderIdentification(
    Env Env,
    string MerchantTradeNo,
    string? AppId = null
);