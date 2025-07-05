using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery;
using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery.ResultModel;

namespace BinancePayConnector.MediatrStyle.Handlers.Wallet;

public class WalletBalanceQueryHandler(
    IBinancePay binancePay
) : IRequestHandler<WalletBalanceQuery, WalletBalanceQueryResult>
{
    public async Task<BinancePayResult<WalletBalanceQueryResult>> ExecuteAsync(
        WalletBalanceQuery command,
        CancellationToken ct = default)
    => await binancePay.WalletBalance.WalletBalanceQuery(command, ct);
}
