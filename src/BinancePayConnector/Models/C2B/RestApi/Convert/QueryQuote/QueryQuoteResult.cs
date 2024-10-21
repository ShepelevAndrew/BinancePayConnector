namespace BinancePayConnector.Models.C2B.RestApi.Convert.QueryQuote;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-convert-query-trade-order#orderstatusresp"/>.
/// </summary>
/// <param name="OrderStatus">SUCCESS/FAIL/PROCESS</param>
public sealed record QueryQuoteResult(
    string OrderId,
    string OrderStatus,
    string FromAsset,
    decimal FromAmount,
    string ToAsset,
    decimal ToAmount,
    decimal Ratio,
    decimal InverseRatio
);
