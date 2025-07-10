using BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutQuery.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.Common.Enums;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutQuery.ResultModel;

/// <param name="PayerId">Payer's payment account ID.</param>
/// <param name="Amount">Amount transferred.</param>
/// <param name="ReceiveType">Enum values from: <see cref="Common.Enums.ReceiveType"/>.</param>
/// <param name="Receiver">Receiver ID from the request.</param>
/// <param name="PayeeId">Receiver's payment account ID.</param>
/// <param name="TransferMethod">Enum values from: <see cref="RestApi.Common.Enums.WalletType"/>.</param>
/// <param name="Status">Enum values from: <see cref="TransferDetailStatus"/>.</param>
public record TransferDetailResult(
    long OrderId,
    string MerchantSendId,
    long PayerId,
    string Amount,
    string ReceiveType,
    string Receiver,
    long PayeeId,
    string TransferMethod,
    string Status,
    string? Remark
);
