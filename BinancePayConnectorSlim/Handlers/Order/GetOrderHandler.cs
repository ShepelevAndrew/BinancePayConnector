using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.QueryOrder;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Order;

public sealed class GetOrderHandler(
    IBinancePayClient client
) : IRequestHandler<QueryOrderRequest, QueryOrderResult>
{
    public async Task<BinancePayResult<QueryOrderResult>> ExecuteAsync(
        QueryOrderRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryOrderResult, QueryOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.QueryOrder,
            content: command,
            ct: ct);

        return response;
    }
}
