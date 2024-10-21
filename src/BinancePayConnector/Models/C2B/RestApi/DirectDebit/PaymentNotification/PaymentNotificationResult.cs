namespace BinancePayConnector.Models.C2B.RestApi.DirectDebit.PaymentNotification;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-directdebit-pay-notify#dataobject"/>.
/// </summary>
public sealed record PaymentNotificationResult(
    string OrderId,
    string MerchantRequestId,
    long TransactionTime
);
