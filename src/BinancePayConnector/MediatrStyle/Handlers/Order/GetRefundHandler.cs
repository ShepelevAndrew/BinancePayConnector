using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryRefund;

namespace BinancePayConnector.MediatrStyle.Handlers.Order;

public class GetRefundHandler(
    IBinancePayClient client
) : IRequestHandler<QueryRefundRequest, QueryRefundResult>
{
    public async Task<BinancePayResult<QueryRefundResult>> ExecuteAsync(
        QueryRefundRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryRefundResult, QueryRefundRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.QueryRefund,
            content: command,
            ct: ct);

        return response;
    }
}