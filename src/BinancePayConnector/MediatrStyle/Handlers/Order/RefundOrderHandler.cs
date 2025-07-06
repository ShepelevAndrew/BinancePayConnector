using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Order.RefundOrder;

namespace BinancePayConnector.MediatrStyle.Handlers.Order;

public class RefundOrderHandler(
    IBinancePayClient client
) : IRequestHandler<RefundOrderRequest, RefundOrderResult>
{
    public async Task<BinancePayResult<RefundOrderResult>> ExecuteAsync(
        RefundOrderRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<RefundOrderResult, RefundOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.RefundOrder,
            content: command,
            ct: ct);

        return response;
    }
}