namespace BinancePayConnector.Core.Domain;

public sealed class BinancePayId
{
    private const byte MaxId32Size = 32;

    public BinancePayId(string value)
    {
        if (!IsValid(value))
            throw new ArgumentException("Invalid BinancePayId. Must be a 32-character alphanumeric string (Guid without dashes).", nameof(value));

        Value = value;
    }

    public string Value { get; }

    public static BinancePayId Generate32()
        => new(CreateBinanceId32());

    /// <summary>
    /// Unique id has letters and digits, with 32 symbols length
    /// </summary>
    /// <returns>Unique identifier</returns>
    private static string CreateBinanceId32()
        => Guid.NewGuid().ToString("N");

    private static bool IsValid(string value)
        => !string.IsNullOrWhiteSpace(value)
               && value.Length <= MaxId32Size
               && value.All(char.IsLetterOrDigit);
}