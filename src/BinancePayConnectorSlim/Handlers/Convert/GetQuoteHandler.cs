using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.QueryQuote;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Convert;

public class GetQuoteHandler(
    IBinancePayClient client
) : IRequestHandler<QueryQuoteRequest, QueryQuoteResult>
{
    public async Task<BinancePayResult<QueryQuoteResult>> ExecuteAsync(
        QueryQuoteRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryQuoteResult, QueryQuoteRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.QueryQuote,
            content: command,
            ct: ct);

        return response;
    }
}
