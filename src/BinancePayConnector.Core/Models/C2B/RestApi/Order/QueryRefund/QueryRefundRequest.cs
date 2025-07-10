using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.QueryRefund;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-refund-query"/>
/// </summary>
public sealed record QueryRefundRequest(
    string RefundRequestId
) : IRequest<QueryRefundResult>;
