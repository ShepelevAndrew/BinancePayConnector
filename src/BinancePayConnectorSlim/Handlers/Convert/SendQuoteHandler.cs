using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.SendQuote;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Convert;

public class SendQuoteHandler(
    IBinancePayClient client
) : IRequestHandler<SendQuoteRequest, SendQuoteResult>
{
    public async Task<BinancePayResult<SendQuoteResult>> ExecuteAsync(
        SendQuoteRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<SendQuoteResult, SendQuoteRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.SendQuote,
            content: command,
            ct: ct);

        return response;
    }
}
