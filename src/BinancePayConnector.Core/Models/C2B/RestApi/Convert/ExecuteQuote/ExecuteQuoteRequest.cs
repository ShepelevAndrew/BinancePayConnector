using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Convert.ExecuteQuote;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-convert-execute-quote#request-parameters"/>.
/// </summary>
/// <param name="QuoteId">Quote Id for execute quote</param>
public sealed record ExecuteQuoteRequest(
    string QuoteId
) : IRequest<ExecuteQuoteResult>;
