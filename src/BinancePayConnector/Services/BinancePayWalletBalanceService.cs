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
    public async Task<BinancePayResult<WalletBalanceQueryResult>> WalletBalanceQuery(
        WalletBalanceQuery request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<WalletBalanceQueryResult, WalletBalanceQuery>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.WalletBalance.WalletBalanceQuery,
            content: request,
            ct: ct);

        return response;
    }
}
