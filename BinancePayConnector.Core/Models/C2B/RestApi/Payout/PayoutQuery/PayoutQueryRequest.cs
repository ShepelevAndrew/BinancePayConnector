using BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutQuery.ResultModel;
using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutQuery;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-payout-query"/>.
/// </summary>
/// <param name="RequestId">The unique ID assigned by the merchant to identify a payout request.</param>
/// <param name="DetailStatus"></param>
public sealed record PayoutQueryRequest(
    string RequestId,
    IEnumerable<string>? DetailStatus = null
) : IRequest<PayoutQueryResult>;
