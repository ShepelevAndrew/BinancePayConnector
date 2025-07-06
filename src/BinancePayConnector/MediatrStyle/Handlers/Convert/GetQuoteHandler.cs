using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Convert.QueryQuote;

namespace BinancePayConnector.MediatrStyle.Handlers.Convert;

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
