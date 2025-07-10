using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.DeleteReceiver;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.ProfitSharing;

public class DeleteReceiverHandler(
    IBinancePayClient client
) : IRequestHandler<DeleteReceiverRequest, DeleteReceiverResult>
{
    public async Task<BinancePayResult<DeleteReceiverResult>> ExecuteAsync(
        DeleteReceiverRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<DeleteReceiverResult, DeleteReceiverRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.DeleteReceiver,
            content: command,
            ct: ct);

        return response;
    }
}