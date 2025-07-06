using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.QueryContract;

namespace BinancePayConnector.MediatrStyle.Handlers.DirectDebit;

public class GetContractHandler(
    IBinancePayClient client
) : IRequestHandler<QueryContractRequest, QueryContractResult>
{
    public async Task<BinancePayResult<QueryContractResult>> ExecuteAsync(
        QueryContractRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryContractResult, QueryContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.QueryContract,
            content: command,
            ct: ct);

        return response;
    }
}
