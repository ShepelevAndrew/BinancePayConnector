using BinancePayConnector.Models.C2B.Common.Enums;

namespace BinancePayConnector.Services.Models.Order.CreateOrder;

public record OrderDetailsCrypto(
    string Description,
    decimal OrderAmount,
    string Currency,
    long? OrderExpireTimeMin = null,
    IEnumerable<AssetType>? SupportPayCurrency = null
) : OrderDetails(Description, OrderExpireTimeMin, SupportPayCurrency);