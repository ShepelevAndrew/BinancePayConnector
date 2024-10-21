using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.Order.RefundOrder;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-refund#request-parameters"/>
/// </summary>
/// <param name="RefundRequestId">The unique ID assigned by the merchant to identify a refund request.The value must be same for one refund request.</param>
/// <param name="PrepayId">The unique ID assigned by Binance for the original order to be refunded.</param>
/// <param name="RefundAmount">You can perform multiple partial refunds, but their sum should not exceed the order amount.</param>
/// <param name="WebhookUrl">The URL for refund order notification.</param>
public sealed record RefundOrder(
    string RefundRequestId,
    string PrepayId,
    decimal RefundAmount,
    string? RefundReason = null,
    string? WebhookUrl = null
) : ICommand<RefundOrderResult>;
