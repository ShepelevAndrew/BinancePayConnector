using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery;
using BinancePayConnector.Core.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery.ResultModel;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Wallet;

public sealed class GetWalletBalanceHandler(
    IBinancePayClient client
) : IRequestHandler<WalletBalanceQueryRequest, WalletBalanceQueryResult>
{
    public async Task<BinancePayResult<WalletBalanceQueryResult>> ExecuteAsync(
        WalletBalanceQueryRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<WalletBalanceQueryResult, WalletBalanceQueryRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.WalletBalance.WalletBalanceQuery,
            content: command,
            ct: ct);

        return response;
    }
}
