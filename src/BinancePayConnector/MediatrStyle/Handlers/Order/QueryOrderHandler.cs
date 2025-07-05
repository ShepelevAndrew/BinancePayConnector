using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;

namespace BinancePayConnector.MediatrStyle.Handlers.Order;

public class QueryOrderHandler(
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
