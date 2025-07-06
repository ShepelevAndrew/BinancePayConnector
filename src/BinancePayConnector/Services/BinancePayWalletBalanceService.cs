using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery;
using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery.ResultModel;
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
