using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.TerminateContract;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.DirectDebit;

public class TerminateContractHandler(
    IBinancePayClient client
) : IRequestHandler<TerminateContractRequest, bool?>
{
    public async Task<BinancePayResult<bool?>> ExecuteAsync(
        TerminateContractRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<bool?, TerminateContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.TerminateContract,
            content: command,
            ct: ct);

        return response;
    }
}
