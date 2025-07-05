using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.Common.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.DirectDebit.PaymentNotification;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-directdebit-pay-notify#request-parameters"/>.
/// </summary>
public sealed record PaymentNotificationRequest(
    string MerchantRequestId,
    long BizId,
    decimal EstimatedAmount,
    string? SubMerchantId = null,
    string TradeMode = "DIRECT_DEBIT",
    string Currency = Assets.Usdt
) : IRequest<PaymentNotificationResult>;
