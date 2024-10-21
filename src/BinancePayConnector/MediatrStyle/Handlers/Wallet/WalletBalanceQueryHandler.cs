using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery;
using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery.ResultModel;
using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector.MediatrStyle.Handlers.Wallet;

public class WalletBalanceQueryHandler(
    IBinancePay binancePay
) : ICommandHandler<WalletBalanceQuery, WalletBalanceQueryResult>
{
    public async Task<BinancePayResult<WalletBalanceQueryResult>> ExecuteAsync(
        WalletBalanceQuery command,
        CancellationToken ct = default)
    => await binancePay.WalletBalance.WalletBalanceQuery(command, ct);
}
