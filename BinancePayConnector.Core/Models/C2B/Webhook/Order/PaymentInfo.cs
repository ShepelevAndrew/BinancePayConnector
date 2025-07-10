namespace BinancePayConnector.Core.Models.C2B.Webhook.Order;

public sealed record PaymentInfo(
    long PayerId,
    string PayMethod,
    List<PaymentInstruction> PaymentInstructions,
    string? Channel = null,
    string? SubChannel = null,
    string? PayerDetail = null
);
