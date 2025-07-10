using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.QueryRefund;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Order;

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