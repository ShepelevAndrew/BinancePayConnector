using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutQuery;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutQuery.ResultModel;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Payout;

public class GetPayoutInfoHandler(
    IBinancePayClient client
) : IRequestHandler<PayoutQueryRequest, PayoutQueryResult>
{
    public async Task<BinancePayResult<PayoutQueryResult>> ExecuteAsync(
        PayoutQueryRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<PayoutQueryResult, PayoutQueryRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Payout.PayoutQuery,
            content: command,
            ct: ct);

        return response;
    }
}
