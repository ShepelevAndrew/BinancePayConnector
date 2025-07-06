namespace BinancePayConnector.Models.C2B.RestApi.Payout.BatchPayout;

public sealed record TransferDetail(
    string MerchantSendId,
    string ReceiveType,
    string Receiver,
    decimal TransferAmount,
    string TransferMethod,
    string? Remark = null,
    string? RegistrationEmail = null,
    string? RegistrationMobileNumber = null,
    string? RegistrationMobileCode = null
);
