using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery;
using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery.ResultModel;
using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayWalletBalanceService
{
    Task<BinancePayResult<WalletBalanceQueryResult>> WalletBalanceQuery(
        WalletBalanceQuery request,
        CancellationToken ct = default);
}
