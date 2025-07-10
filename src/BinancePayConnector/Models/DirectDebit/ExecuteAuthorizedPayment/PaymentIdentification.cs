namespace BinancePayConnector.Models.DirectDebit.ExecuteAuthorizedPayment;

public sealed record PaymentIdentification(
    string MerchantRequestId,
    long BizId
);