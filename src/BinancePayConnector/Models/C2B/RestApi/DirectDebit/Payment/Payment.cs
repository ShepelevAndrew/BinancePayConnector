using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.Common.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.DirectDebit.Payment;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-directdebit-pay-apply#request-parameters"/>.
/// </summary>
/// <param name="MerchantRequestId">The order id, Unique identifier for the request, idempotent result will be returned for same requestId.</param>
/// <param name="BizId">Business orderId like contractId.</param>
/// <param name="Amount">Amount to be deducted, please ensure the amount do not exceed the singleUpperLimit of the contract.</param>
/// <param name="SubMerchantId">The sub merchant account id, issued when sub merchant been created at Binance, The parameter subMerchantId is required when configuring show subMerchant info.</param>
/// <param name="PreBizId">Prerequisite orderId like pay notification orderId for periodic debit scenario.</param>
/// <param name="WebhookUrl">The URL for order notification.</param>
public sealed record Payment(
    string MerchantRequestId,
    long BizId,
    decimal Amount,
    string ProductName,
    string TradeMode = "DIRECT_DEBIT",
    string Currency = Assets.Usdt,
    string? SubMerchantId = null,
    long? PreBizId = null,
    string? ProductType = null,
    string? ProductDetail = null,
    string? WebhookUrl = null,
    OrderTag? OrderTags = null
) : ICommand<PaymentResult>;
