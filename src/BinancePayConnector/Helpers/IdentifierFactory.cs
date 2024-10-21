namespace BinancePayConnector.Helpers;

public static class IdentifierFactory
{
    /// <summary>
    /// Unique id has letters and digits, with 32 symbols length
    /// </summary>
    /// <returns>Unique identifier</returns>
    public static string CreateBinanceId32()
        => Guid.NewGuid().ToString("N");
}
