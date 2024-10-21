namespace BinancePayConnector.Config.Options;

public sealed class BinancePayWebhookConfig
{
    public required string BaseUri { get; init; }

    public string? OrderRoute { get; init; }
}
