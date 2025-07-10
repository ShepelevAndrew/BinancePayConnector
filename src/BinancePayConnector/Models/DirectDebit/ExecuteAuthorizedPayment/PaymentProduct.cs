namespace BinancePayConnector.Models.DirectDebit.ExecuteAuthorizedPayment;

public sealed record PaymentProduct(
    string ProductName,
    string? ProductType = null,
    string? ProductDetail = null
);