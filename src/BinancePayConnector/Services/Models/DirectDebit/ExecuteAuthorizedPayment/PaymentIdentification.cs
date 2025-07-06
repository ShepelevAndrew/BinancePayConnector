namespace BinancePayConnector.Services.Models.DirectDebit.ExecuteAuthorizedPayment;

public sealed record PaymentIdentification(
    string MerchantRequestId,
    long BizId
);