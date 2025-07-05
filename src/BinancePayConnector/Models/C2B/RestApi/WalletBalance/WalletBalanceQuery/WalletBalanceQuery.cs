using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery.ResultModel;

namespace BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-balance-query-v2#request-parameters"/>.
/// </summary>
/// <param name="Wallet">Binance wallet to query, currently supported enum values: <see cref="BinancePayConnector.Models.C2B.RestApi.Common.Enums.WalletType"/>.</param>
/// <param name="Currency">Currency to query, enum values from <see cref="Assets"/>.
/// If no currency was sent, return all assets.</param>
public sealed record WalletBalanceQuery(
    string Wallet,
    string? Currency = null
) : IRequest<WalletBalanceQueryResult>;
