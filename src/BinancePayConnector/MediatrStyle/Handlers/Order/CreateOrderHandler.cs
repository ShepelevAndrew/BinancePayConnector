using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;

namespace BinancePayConnector.MediatrStyle.Handlers.Order;

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
