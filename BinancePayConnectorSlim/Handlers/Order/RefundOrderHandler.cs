using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.RefundOrder;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Order;

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