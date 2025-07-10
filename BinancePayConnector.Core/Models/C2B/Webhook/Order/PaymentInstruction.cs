namespace BinancePayConnector.Core.Models.C2B.Webhook.Order;

public sealed record PaymentInstruction(
    string Currency,
    decimal Amount,
    decimal Price
);
