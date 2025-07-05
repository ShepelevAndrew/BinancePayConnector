namespace BinancePayConnector.Services.Models.Order;

public record OrderUrls(
    string? WebhookUrl = null,
    string? ReturnUrl = null,
    string? CancelUrl = null,
    string? UniversalUrlAttach = null
);
