using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.Convert.ExecuteQuote;
using BinancePayConnector.Models.C2B.RestApi.Convert.ListAllConvertPairs;
using BinancePayConnector.Models.C2B.RestApi.Convert.QueryQuote;
using BinancePayConnector.Models.C2B.RestApi.Convert.SendQuote;
using BinancePayConnector.Services.Interfaces;

namespace BinancePayConnector.Services;

public class BinancePayConvertService(
    IBinancePayClient client
) : IBinancePayConvertService
{
    public async Task<BinancePayResult<ListAllConvertPairsResult>> GetListAllConvertPairs(
        string fromAsset,
        CancellationToken ct = default)
    {
        var request = new ListAllConvertPairsRequest(fromAsset);
        var response = await client.SendBinanceAsync<ListAllConvertPairsResult, ListAllConvertPairsRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.ListAllConvertPairs,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<SendQuoteResult>> SendQuote(
        string wallet,
        string fromAsset,
        string toAsset,
        decimal? fromAmount,
        decimal toAmount,
        CancellationToken ct = default)
    {
        var request = new SendQuoteRequest(wallet, fromAsset, toAsset, fromAmount, toAmount);
        var response = await client.SendBinanceAsync<SendQuoteResult, SendQuoteRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.SendQuote,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<ExecuteQuoteResult>> ExecuteQuote(
        string quoteId,
        CancellationToken ct = default)
    {
        var request = new ExecuteQuoteRequest(quoteId);
        var response = await client.SendBinanceAsync<ExecuteQuoteResult, ExecuteQuoteRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.ExecuteQuote,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryQuoteResult>> QueryQuote(
        string orderId,
        CancellationToken ct = default)
    {
        var request = new QueryQuoteRequest(orderId);
        var response = await client.SendBinanceAsync<QueryQuoteResult, QueryQuoteRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Convert.QueryQuote,
            content: request,
            ct: ct);

        return response;
    }
}
