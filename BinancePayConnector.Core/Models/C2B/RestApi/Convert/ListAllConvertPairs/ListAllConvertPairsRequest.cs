using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Convert.ListAllConvertPairs;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-convert-get-to-selector#request-parameters"/>.
/// </summary>
/// <param name="FromAsset">Enum values from: <see cref="Assets"/>.</param>
public sealed record ListAllConvertPairsRequest(
    string FromAsset
) : IRequest<ListAllConvertPairsResult>;
