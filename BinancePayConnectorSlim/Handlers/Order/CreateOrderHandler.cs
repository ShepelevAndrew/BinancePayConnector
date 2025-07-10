using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Order;

public sealed class CreateOrderHandler(
    IBinancePayClient client
) : IRequestHandler<CreateOrderRequest, CreateOrderResult>
{
    public async Task<BinancePayResult<CreateOrderResult>> ExecuteAsync(
        CreateOrderRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<CreateOrderResult, CreateOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CreateOrder,
            content: command,
            ct: ct);

        return response;
    }
}
