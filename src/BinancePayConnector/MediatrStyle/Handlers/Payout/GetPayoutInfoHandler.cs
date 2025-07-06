using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery.ResultModel;

namespace BinancePayConnector.MediatrStyle.Handlers.Payout;

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
