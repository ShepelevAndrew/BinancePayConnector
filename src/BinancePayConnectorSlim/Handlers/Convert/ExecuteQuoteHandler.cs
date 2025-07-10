using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.ExecuteQuote;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Convert;

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
