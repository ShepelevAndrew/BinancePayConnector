using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.CreateContract;

namespace BinancePayConnector.MediatrStyle.Handlers.DirectDebit;

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
