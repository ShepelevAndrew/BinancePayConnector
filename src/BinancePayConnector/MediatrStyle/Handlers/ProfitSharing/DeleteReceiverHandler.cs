using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.DeleteReceiver;

namespace BinancePayConnector.MediatrStyle.Handlers.ProfitSharing;

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