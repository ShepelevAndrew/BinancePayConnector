using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.Order.QueryRefund;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-refund-query"/>
/// </summary>
public sealed record QueryRefund(
    string RefundRequestId
) : ICommand<QueryRefundResult>;
