using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.Enums;

namespace BinancePayConnector.Core.Models.C2B.Webhook.RefundOrder;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/refund-order-notification#notification-data"/>.
/// </summary>
/// <param name="MerchantTradeNo">The order id.</param>
/// <param name="TradeType">Enum values from: <see cref="TerminalType"/>.</param>
/// <param name="TotalFee">Order amount.</param>
/// <param name="Currency">Enum values from: <see cref="Assets"/>.</param>
/// <param name="OpenUserId">Consumer unique id.</param>
/// <param name="RefundInfo">Only merchant got approved by Binance Operation's approval will receive this payerInfo.</param>
public sealed record RefundOrderNotification(
    string MerchantTradeNo,
    string ProductType,
    string ProductName,
    string TradeType,
    decimal TotalFee,
    string Currency,
    string? OpenUserId = null,
    RefundInfo? RefundInfo = null
);