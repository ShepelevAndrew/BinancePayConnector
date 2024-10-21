using BinancePayConnector.Models.C2B.RestApi.Convert.ExecuteQuote;
using BinancePayConnector.Models.C2B.RestApi.Convert.ListAllConvertPairs;
using BinancePayConnector.Models.C2B.RestApi.Convert.QueryQuote;
using BinancePayConnector.Models.C2B.RestApi.Convert.SendQuote;
using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayConvertService
{
    Task<BinancePayResult<ListAllConvertPairsResult>> GetListAllConvertPairs(
        ListAllConvertPairs request,
        CancellationToken ct = default);

    Task<BinancePayResult<SendQuoteResult>> SendQuote(
        SendQuote request,
        CancellationToken ct = default);

    Task<BinancePayResult<ExecuteQuoteResult>> ExecuteQuote(
        ExecuteQuote request,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryQuoteResult>> QueryQuote(
        QueryQuote request,
        CancellationToken ct = default);
}
