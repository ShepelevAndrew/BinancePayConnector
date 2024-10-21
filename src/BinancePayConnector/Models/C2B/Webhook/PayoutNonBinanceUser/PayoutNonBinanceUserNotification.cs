using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Payout.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery.Enums;

namespace BinancePayConnector.Models.C2B.Webhook.PayoutNonBinanceUser;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/webhook-payout-non-binance#payoutorderdetail"/>.
/// </summary>
/// <param name="MerchantSendId">Unique identifier for the merchant sending the payout.</param>
/// <param name="OrderId">Unique identifier for the order associated with this payout.</param>
/// <param name="BatchId">Batch identifier grouping multiple payouts.</param>
/// <param name="Status">Enum values from: <see cref="TransferDetailStatus"/>.</param>
/// <param name="Currency">The currency in which the payout is made. Enum values from: <see cref="Assets"/>.</param>
/// <param name="Amount">The total amount of the payout.</param>
/// <param name="ReceiveType">Receiver's ID type only will be Email. Enum values from: <see cref="RestApi.Payout.Common.Enums.ReceiveType"/>.</param>
/// <param name="Receiver">The email of this receiver.</param>
public sealed record PayoutNonBinanceUserNotification(
    string MerchantSendId,
    string OrderId,
    string BatchId,
    string Status,
    string Currency,
    decimal Amount,
    string Receiver,
    string ReceiveType = ReceiveType.Email
);
