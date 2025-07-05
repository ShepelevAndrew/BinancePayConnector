namespace BinancePayConnector.Services.Models.Order;

public record OrderDetailsCrypto(
    string Description,
    decimal OrderAmount,
    string Currency,
    long? OrderExpireTimeMin = null,
    string? SupportPayCurrency = null
) : OrderDetails(Description, OrderExpireTimeMin, SupportPayCurrency);