using BinancePayConnector.Core.Models.C2B.Common.Enums;

namespace BinancePayConnector.Models.Order.CreateOrder;

public record OrderDetails(
    string Description,
    long? OrderExpireTimeMin = null,
    IEnumerable<AssetType>? SupportPayCurrency = null
);