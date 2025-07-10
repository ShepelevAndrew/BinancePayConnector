using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.ExecuteQuote;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.ListAllConvertPairs;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.QueryQuote;
using BinancePayConnector.Core.Models.C2B.RestApi.Convert.SendQuote;
using BinancePayConnector.Models.Convert.SendQuote;

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
