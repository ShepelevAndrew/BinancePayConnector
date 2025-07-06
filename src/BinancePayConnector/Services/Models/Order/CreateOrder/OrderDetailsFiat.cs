using BinancePayConnector.Models.C2B.Common.Enums;

namespace BinancePayConnector.Services.Models.Order.CreateOrder;

public record OrderDetailsFiat(
    string Description,
    decimal FiatAmount,
    string FiatCurrency,
    long? OrderExpireTimeMin = null,
    IEnumerable<AssetType>? SupportPayCurrency = null
) : OrderDetails(Description, OrderExpireTimeMin, SupportPayCurrency);