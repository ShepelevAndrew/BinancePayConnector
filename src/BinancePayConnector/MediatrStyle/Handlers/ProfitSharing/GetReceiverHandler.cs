using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.QueryReceiver;

namespace BinancePayConnector.MediatrStyle.Handlers.ProfitSharing;

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
