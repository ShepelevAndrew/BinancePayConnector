namespace BinancePayConnector.Services.Models.Order;

public record OrderDetails(
    string Description,
    long? OrderExpireTimeMin = null,
    string? SupportPayCurrency = null
);