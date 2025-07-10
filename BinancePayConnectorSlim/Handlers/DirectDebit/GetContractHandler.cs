using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.QueryContract;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.DirectDebit;

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
