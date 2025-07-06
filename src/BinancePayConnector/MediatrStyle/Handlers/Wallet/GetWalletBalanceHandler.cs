using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery;
using BinancePayConnector.Models.C2B.RestApi.WalletBalance.WalletBalanceQuery.ResultModel;

namespace BinancePayConnector.MediatrStyle.Handlers.Wallet;

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
