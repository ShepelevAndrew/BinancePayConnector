namespace BinancePayConnector.Models.Order.CreateOrder;

public record OrderUrls(
    string? WebhookUrl = null,
    string? ReturnUrl = null,
    string? CancelUrl = null,
    string? UniversalUrlAttach = null
);
