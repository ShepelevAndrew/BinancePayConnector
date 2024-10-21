namespace BinancePayConnector.Models.C2B.RestApi.Order.QueryRefund;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-refund-query#refundresult"/>
/// </summary>
/// <param name="RefundRequestId">The unique ID assigned by the merchant to identify a refund request.</param>
/// <param name="PrepayId">The unique ID assigned by Binance for the original order to be refunded.</param>
/// <param name="OrderAmount">The total amount of prepay order.</param>
/// <param name="RefundedAmount">The total refunded amount included this refund request.</param>
/// <param name="RefundAmount">The refund amount of this refund request.</param>
/// <param name="RemainingAttempts">The remaining attempts of this original order.
/// If this value becomes 1, then your next refund request amount will be ignored.
/// We will refund all the remaining amount of this original order.</param>
/// <param name="PayerOpenId">The payer open id of this refund which is the merchant open id.</param>
/// <param name="RefundStatus">The status of this refund. Enum values from <see cref="Order.QueryRefund.RefundStatus"/>.</param>
public sealed record QueryRefundResult(
    string RefundRequestId,
    string PrepayId,
    string OrderAmount,
    string RefundedAmount,
    string RefundAmount,
    int RemainingAttempts,
    string PayerOpenId,
    string RefundStatus
);
