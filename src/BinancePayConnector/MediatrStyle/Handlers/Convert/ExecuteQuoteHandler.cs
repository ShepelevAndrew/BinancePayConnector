using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Convert.ExecuteQuote;

namespace BinancePayConnector.MediatrStyle.Handlers.Convert;

public class ExecuteQuoteHandler(
    IBinancePayClient client
) : IRequestHandler<ExecuteQuoteRequest, ExecuteQuoteResult>
{
    public async Task<BinancePayResult<ExecuteQuoteResult>> ExecuteAsync(
        ExecuteQuoteRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<ExecuteQuoteResult, ExecuteQuoteRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.ExecuteQuote,
            content: command,
            ct: ct);

        return response;
    }
}
