using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.Convert.ExecuteQuote;
using BinancePayConnector.Models.C2B.RestApi.Convert.ListAllConvertPairs;
using BinancePayConnector.Models.C2B.RestApi.Convert.QueryQuote;
using BinancePayConnector.Models.C2B.RestApi.Convert.SendQuote;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Services.Models.Result;
using BinancePayConnector.Services.Extensions;

namespace BinancePayConnector.Services;

public class BinancePayConvertService(
    IBinancePayClient client)
        : IBinancePayConvertService
{
    public async Task<BinancePayResult<ListAllConvertPairsResult>> GetListAllConvertPairs(
        ListAllConvertPairs request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<ListAllConvertPairsResult, ListAllConvertPairs>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Convert.ListAllConvertPairs,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<ListAllConvertPairsResult>();
        }
    }

    public async Task<BinancePayResult<SendQuoteResult>> SendQuote(
        SendQuote request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<SendQuoteResult, SendQuote>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Convert.SendQuote,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<SendQuoteResult>();
        }
    }

    public async Task<BinancePayResult<ExecuteQuoteResult>> ExecuteQuote(
        ExecuteQuote request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<ExecuteQuoteResult, ExecuteQuote>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Convert.ExecuteQuote,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<ExecuteQuoteResult>();
        }
    }

    public async Task<BinancePayResult<QueryQuoteResult>> QueryQuote(
        QueryQuote request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<QueryQuoteResult, QueryQuote>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Convert.QueryQuote,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<QueryQuoteResult>();
        }
    }
}
