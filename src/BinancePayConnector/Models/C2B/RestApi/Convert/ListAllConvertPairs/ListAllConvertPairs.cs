using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.Common.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.Convert.ListAllConvertPairs;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-convert-get-to-selector#request-parameters"/>.
/// </summary>
/// <param name="FromAsset">Enum values from: <see cref="Assets"/>.</param>
public sealed record ListAllConvertPairs(
    string FromAsset
) : ICommand<ListAllConvertPairsResult>;
