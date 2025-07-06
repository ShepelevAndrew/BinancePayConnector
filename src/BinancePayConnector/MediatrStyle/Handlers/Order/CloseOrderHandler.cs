using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Order.CloseOrder;

namespace BinancePayConnector.MediatrStyle.Handlers.Order;

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
