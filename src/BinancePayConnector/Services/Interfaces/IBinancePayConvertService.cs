using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.Convert.ExecuteQuote;
using BinancePayConnector.Models.C2B.RestApi.Convert.ListAllConvertPairs;
using BinancePayConnector.Models.C2B.RestApi.Convert.QueryQuote;
using BinancePayConnector.Models.C2B.RestApi.Convert.SendQuote;
using BinancePayConnector.Services.Models.Convert.SendQuote;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayConvertService
{
    Task<BinancePayResult<ListAllConvertPairsResult>> GetListAllConvertPairs(
        string fromAsset,
        CancellationToken ct = default);

    Task<BinancePayResult<SendQuoteResult>> SendQuote(
        string wallet,
        AssetConversion conversion,
        CancellationToken ct = default);

    Task<BinancePayResult<ExecuteQuoteResult>> ExecuteQuote(
        string quoteId,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryQuoteResult>> GetQuote(
        string orderId,
        CancellationToken ct = default);
}
