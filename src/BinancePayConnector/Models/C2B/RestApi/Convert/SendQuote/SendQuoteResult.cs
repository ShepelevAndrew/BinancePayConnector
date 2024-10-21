namespace BinancePayConnector.Models.C2B.RestApi.Convert.SendQuote;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-convert-get-quote#sendquoteresp"/>.
/// </summary>
public sealed record SendQuoteResult(
    decimal Ratio,
    decimal InverseRatio,
    decimal ValidTimestamp,
    decimal ExpireTime,
    decimal ToAmount,
    string ToCoin,
    decimal FromAmount,
    string FromCoin,
    string? QuoteId = null
);
