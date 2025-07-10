using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CloseOrder;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Order;

public sealed class CloseOrderHandler(
    IBinancePayClient client
) : IRequestHandler<CloseOrderRequest, bool?>
{
    public async Task<BinancePayResult<bool?>> ExecuteAsync(
        CloseOrderRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<bool?, CloseOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CloseOrder,
            content: command,
            ct: ct);

        return response;
    }
}
