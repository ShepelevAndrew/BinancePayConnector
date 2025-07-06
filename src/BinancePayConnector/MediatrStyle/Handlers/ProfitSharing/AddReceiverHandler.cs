using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.AddReceiver;

namespace BinancePayConnector.MediatrStyle.Handlers.ProfitSharing;

public class AddReceiverHandler(
    IBinancePayClient client
) : IRequestHandler<AddReceiverRequest, AddReceiverResult>
{
    public async Task<BinancePayResult<AddReceiverResult>> ExecuteAsync(
        AddReceiverRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<AddReceiverResult, AddReceiverRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.AddReceiver,
            content: command,
            ct: ct);

        return response;
    }
}
