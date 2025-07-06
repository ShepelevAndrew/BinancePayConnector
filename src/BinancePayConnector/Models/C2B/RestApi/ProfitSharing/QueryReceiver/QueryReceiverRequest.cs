using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.ProfitSharing.QueryReceiver;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-query-receiver#request-parameters"/>.
/// </summary>
/// <param name="PageNum">Pagination number. Starts from 1.</param>
/// <param name="PageSize">Pagination size, number of receivers in a page.</param>
public sealed record QueryReceiverRequest(
    int PageNum,
    int PageSize
) : IRequest<QueryReceiverResult>;
