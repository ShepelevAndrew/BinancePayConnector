namespace BinancePayConnector.Services.Models.Order;

public record OrderDetailsFiat(
    string Description,
    decimal FiatAmount,
    string FiatCurrency,
    long? OrderExpireTimeMin = null,
    string? SupportPayCurrency = null
) : OrderDetails(Description, OrderExpireTimeMin, SupportPayCurrency);