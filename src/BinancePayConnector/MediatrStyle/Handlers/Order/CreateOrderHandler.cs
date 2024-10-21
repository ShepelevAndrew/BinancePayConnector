using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Services.Extensions;
using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector.MediatrStyle.Handlers.Order;

public class CreateOrderHandler(
    IBinancePayClient client
) : ICommandHandler<CreateOrder, CreateOrderResult>
{
    public async Task<BinancePayResult<CreateOrderResult>> ExecuteAsync(
        CreateOrder command,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<CreateOrderResult, CreateOrder>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Order.CreateOrder,
                content: command,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<CreateOrderResult>();
        }
    }
}
