using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery;
using BinancePayConnector.Core.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery.ResultModel;
using BinancePayConnector.Services.Interfaces;

namespace BinancePayConnector.Services;

public class BinancePayWalletBalanceService(
    IBinancePayClient client
) : IBinancePayWalletBalanceService
{
    public async Task<BinancePayResult<WalletBalanceQueryResult>> GetWalletBalance(
        string wallet,
        string? currency = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<WalletBalanceQueryResult, WalletBalanceQueryRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.WalletBalance.WalletBalanceQuery,
            content: new WalletBalanceQueryRequest(wallet, currency),
            ct: ct);

        return response;
    }
}
