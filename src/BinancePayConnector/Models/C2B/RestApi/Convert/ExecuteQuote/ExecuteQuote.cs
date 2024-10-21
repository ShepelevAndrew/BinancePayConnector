using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.Convert.ExecuteQuote;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-convert-execute-quote#request-parameters"/>.
/// </summary>
/// <param name="QuoteId">Quote Id for execute quote</param>
public sealed record ExecuteQuote(
    string QuoteId
) : ICommand<ExecuteQuoteResult>;
