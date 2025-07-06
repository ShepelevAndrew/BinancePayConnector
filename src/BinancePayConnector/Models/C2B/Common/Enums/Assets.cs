namespace BinancePayConnector.Models.C2B.Common.Enums;

public static class Assets
{
    public const string Usdt = "USDT";
    public const string Btc = "BTC";
    public const string Bnb = "BNB";

    public static string ConvertToString(this AssetType asset) => asset switch
    {
        AssetType.Usdt => Usdt,
        AssetType.Btc => Btc,
        AssetType.Bnb => Bnb,
        _ => throw new ArgumentOutOfRangeException(nameof(asset), asset, "Unknown asset type")
    };
}

public enum AssetType
{
    Usdt,
    Btc,
    Bnb
}
