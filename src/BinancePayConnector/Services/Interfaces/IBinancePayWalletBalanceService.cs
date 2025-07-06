using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery.ResultModel;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayWalletBalanceService
{
    /// <summary>
    /// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-balance-query-v2#request-parameters"/>.
    /// </summary>
    /// <param name="wallet">Binance wallet to query, currently supported enum values: <see cref="BinancePayConnector.Models.C2B.RestApi.Common.Enums.WalletType"/>.</param>
    /// <param name="currency">Currency to query, enum values from <see cref="BinancePayConnector.Models.C2B.Common.Enums.Assets"/>.
    /// If no currency was sent, return all assets.</param>
    /// <param name="ct">Cancellation token.</param>
    Task<BinancePayResult<WalletBalanceQueryResult>> GetWalletBalance(
        string wallet,
        string? currency = null,
        CancellationToken ct = default);
}
