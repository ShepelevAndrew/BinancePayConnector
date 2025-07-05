using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.Convert.QueryQuote;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-convert-query-trade-order#request-parameters"/>.
/// </summary>
/// <param name="OrderId">Order id for order query.</param>
public sealed record QueryQuoteRequest(
    string OrderId
) : IRequest<QueryQuoteResult>;
