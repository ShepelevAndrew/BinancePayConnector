using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.ExecuteQuote;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.ListAllConvertPairs;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.QueryQuote;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.SendQuote;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Models.Convert.SendQuote;

namespace BinancePayConnector.Services;

public class BinancePayConvertService(
    IBinancePayClient client
) : IBinancePayConvertService
{
    public async Task<BinancePayResult<ListAllConvertPairsResult>> GetListAllConvertPairs(
        string fromAsset,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<ListAllConvertPairsResult, ListAllConvertPairsRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.ListAllConvertPairs,
            content: new ListAllConvertPairsRequest(fromAsset),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<SendQuoteResult>> SendQuote(
        string wallet,
        AssetConversion conversion,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<SendQuoteResult, SendQuoteRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.SendQuote,
            content: new SendQuoteRequest(
                wallet,
                conversion.FromAsset,
                conversion.ToAsset,
                conversion.FromAmount,
                conversion.ToAmount),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<ExecuteQuoteResult>> ExecuteQuote(
        string quoteId,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<ExecuteQuoteResult, ExecuteQuoteRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.ExecuteQuote,
            content: new ExecuteQuoteRequest(quoteId),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryQuoteResult>> GetQuote(
        string orderId,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryQuoteResult, QueryQuoteRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.QueryQuote,
            content: new QueryQuoteRequest(orderId),
            ct: ct);

        return response;
    }
}
