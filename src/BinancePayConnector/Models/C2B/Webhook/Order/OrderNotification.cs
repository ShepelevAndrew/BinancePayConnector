using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.Enums;

namespace BinancePayConnector.Models.C2B.Webhook.Order;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/order-notification#request-parameters"/>.
/// </summary>
/// <param name="MerchantTradeNo">The order id.</param>
/// <param name="TradeType">Enum values from: <see cref="TerminalType"/>.</param>
/// <param name="TotalFee">Order amount.</param>
/// <param name="Commission">Transaction fees charged. Please refer to your contract for more info.</param>
/// <param name="TransactionId">Debit transaction id.</param>
/// <param name="OpenUserId">Payer unique id.</param>
/// <param name="PassThroughInfo">Pass through info, from the <see cref="CreateOrder"/>.</param>
public sealed record OrderNotification(
    string MerchantTradeNo,
    string ProductType,
    string ProductName,
    long TransactTime,
    string TradeType,
    decimal TotalFee,
    string Currency,
    decimal Commission,
    string? TransactionId = null,
    string? OpenUserId = null,
    string? PassThroughInfo = null,
    PaymentInfo? PaymentInfo = null
);
