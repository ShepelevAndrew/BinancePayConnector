namespace BinancePayConnector.Models.C2B.RestApi.Convert.ListAllConvertPairs;

public sealed record ConvertPairData(
    string Coin,
    decimal FromMin,
    decimal FromMax,
    decimal ToMin,
    decimal ToMax,
    bool Reverse,
    bool Base
);
