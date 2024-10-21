using BinancePayConnector.Models.C2B.Common.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery.ResultModel;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-balance-query-v2#assetquerydata"/>.
/// </summary>
/// <param name="Available">Current balance free to use.</param>
/// <param name="Freeze">Current balance frozen.</param>
/// <param name="Asset">Enum values from: <see cref="Assets"/>.</param>
public sealed record AssetQueryData(
    decimal Available,
    decimal Freeze,
    string Asset,
    decimal AvailableFiatValuation,
    decimal AvailableBtcValuation
);
