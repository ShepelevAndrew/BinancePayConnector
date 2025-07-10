using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.CreateContract;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.DirectDebit;

public class CreateContractHandler(
    IBinancePayClient client
) : IRequestHandler<CreateContractRequest, CreateContractResult>
{
    public async Task<BinancePayResult<CreateContractResult>> ExecuteAsync(
        CreateContractRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<CreateContractResult, CreateContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.CreateContract,
            content: command,
            ct: ct);

        return response;
    }
}
