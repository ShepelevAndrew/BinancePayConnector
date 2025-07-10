using BinancePayConnector.Core.Models.C2B.RestApi.Common.Enums;

namespace BinancePayConnector.Core.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery.ResultModel;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-balance-query-v2#assetqueryrespv2"/>.
/// </summary>
/// <param name="Wallet">Wallet that contains the currencies. Enum values from: <see cref="WalletType"/>.</param>
/// <param name="UpdateTime">Update time of the data.</param>
/// <param name="Fiat">Fiat name, for fiat valuation.</param>
/// <param name="Balance">Currency data.</param>
public sealed record WalletBalanceQueryResult(
    string Wallet,
    string UpdateTime,
    string Fiat,
    IEnumerable<AssetQueryData>? Balance = null
);
