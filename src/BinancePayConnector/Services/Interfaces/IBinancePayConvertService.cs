using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.Convert.ExecuteQuote;
using BinancePayConnector.Models.C2B.RestApi.Convert.ListAllConvertPairs;
using BinancePayConnector.Models.C2B.RestApi.Convert.QueryQuote;
using BinancePayConnector.Models.C2B.RestApi.Convert.SendQuote;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayConvertService
{
    Task<BinancePayResult<ListAllConvertPairsResult>> GetListAllConvertPairs(
        string fromAsset,
        CancellationToken ct = default);

    Task<BinancePayResult<SendQuoteResult>> SendQuote(
        string wallet,
        string fromAsset,
        string toAsset,
        decimal? fromAmount,
        decimal toAmount,
        CancellationToken ct = default);

    Task<BinancePayResult<ExecuteQuoteResult>> ExecuteQuote(
        string quoteId,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryQuoteResult>> QueryQuote(
        string orderId,
        CancellationToken ct = default);
}
