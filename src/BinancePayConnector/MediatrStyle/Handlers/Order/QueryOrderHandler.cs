using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;
using BinancePayConnector.Services.Extensions;
using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector.MediatrStyle.Handlers.Order;

public class QueryOrderHandler(
    IBinancePayClient client
) : ICommandHandler<QueryOrder, QueryOrderResult>
{
    public async Task<BinancePayResult<QueryOrderResult>> ExecuteAsync(
        QueryOrder command,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<QueryOrderResult, QueryOrder>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Order.QueryOrder,
                content: command,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<QueryOrderResult>();
        }
    }
}
