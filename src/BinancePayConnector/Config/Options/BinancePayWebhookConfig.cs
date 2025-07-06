namespace BinancePayConnector.Config.Options;

public sealed class BinancePayWebhookConfig
{
    public string BaseUri { get; init; } = null!;

    public string? OrderRoute { get; init; }
}
