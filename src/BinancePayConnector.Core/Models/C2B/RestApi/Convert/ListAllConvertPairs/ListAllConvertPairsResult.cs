namespace BinancePayConnector.Core.Models.C2B.RestApi.Convert.ListAllConvertPairs;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-convert-get-to-selector#convertpairresp"/>.
/// </summary>
public sealed record ListAllConvertPairsResult(
    List<ConvertPairData> ToList,
    string Coin
);
