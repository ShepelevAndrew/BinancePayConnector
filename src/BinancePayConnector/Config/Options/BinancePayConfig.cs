namespace BinancePayConnector.Config.Options;

public sealed class BinancePayConfig
{
    public const string BinancePay = nameof(BinancePay);

    public string ApiKey { get; set; } = null!;

    public string ApiSecret { get; set; } = null!;
}
