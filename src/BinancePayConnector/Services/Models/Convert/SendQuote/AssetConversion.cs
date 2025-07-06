namespace BinancePayConnector.Services.Models.Convert.SendQuote;

public sealed record AssetConversion(
    string FromAsset,
    string ToAsset,
    decimal? FromAmount,
    decimal ToAmount
);