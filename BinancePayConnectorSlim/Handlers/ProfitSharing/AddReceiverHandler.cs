using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.AddReceiver;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.ProfitSharing;

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
