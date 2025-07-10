using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.QueryReceiver;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.ProfitSharing;

public class GetReceiverHandler(
    IBinancePayClient client
) : IRequestHandler<QueryReceiverRequest, QueryReceiverResult>
{
    public async Task<BinancePayResult<QueryReceiverResult>> ExecuteAsync(
        QueryReceiverRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryReceiverResult, QueryReceiverRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.QueryReceiver,
            content: command,
            ct: ct);

        return response;
    }
}
