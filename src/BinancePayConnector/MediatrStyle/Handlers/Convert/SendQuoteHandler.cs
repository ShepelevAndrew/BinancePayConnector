using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Convert.SendQuote;

namespace BinancePayConnector.MediatrStyle.Handlers.Convert;

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
