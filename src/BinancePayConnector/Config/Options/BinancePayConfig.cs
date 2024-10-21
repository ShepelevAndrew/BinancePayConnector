namespace BinancePayConnector.Config.Options;

public sealed class BinancePayConfig
{
    public const string BinancePay = nameof(BinancePay);

    public required string ApiKey { get; set; }

    public required string ApiSecret { get; set; }
}
