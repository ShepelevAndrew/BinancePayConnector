using BinancePayConnector.Models.C2B.Common.Enums;

namespace BinancePayConnector.Services.Models.Order.CreateOrder;

public record OrderDetails(
    string Description,
    long? OrderExpireTimeMin = null,
    IEnumerable<AssetType>? SupportPayCurrency = null
);