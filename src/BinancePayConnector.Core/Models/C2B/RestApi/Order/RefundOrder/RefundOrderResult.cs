namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.RefundOrder;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-refund#refundresult"/>
/// </summary>
/// <param name="RefundRequestId">The unique ID assigned by the merchant to identify a refund request.</param>
/// <param name="PrepayId">The unique ID assigned by Binance for the original order to be refunded.</param>
/// <param name="OrderAmount">The total amount of prepay order.</param>
/// <param name="RefundedAmount">The total refunded amount included this refund request.</param>
/// <param name="RefundAmount">The refund amount of this refund request.</param>
/// <param name="RemainingAttempts">The remaining attempts of this original order.
/// If this value becomes 1, then your next refund request amount will be ignored.
/// We will refund all the remaing amount of this original order.</param>
/// <param name="PayerOpenId">The payer open id of this refund which is the merchant open id.</param>
/// <param name="DuplicateRequest">The flag to mark this request refundRequestId is duplicate or not. It will be 'Y' or 'N'</param>
public record RefundOrderResult(
    string RefundRequestId,
    string PrepayId,
    string OrderAmount,
    string RefundedAmount,
    string RefundAmount,
    int RemainingAttempts,
    string PayerOpenId,
    string DuplicateRequest
);
