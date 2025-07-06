using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.TerminateContract;

namespace BinancePayConnector.MediatrStyle.Handlers.DirectDebit;

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
