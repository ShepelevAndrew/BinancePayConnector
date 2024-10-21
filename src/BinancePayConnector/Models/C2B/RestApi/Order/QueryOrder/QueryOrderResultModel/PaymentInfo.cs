namespace BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;

/// <param name="PayerDetail">Encrypted payer identity information for merchant compliance purposes without compromising privacy and security. Decryption instructions please.</param>
public sealed record PaymentInfo(
    string PayerId,
    string PayMethod,
    List<PaymentInstruction> PaymentInstructions,
    string? Channel = null,
    string? SubChannel = null,
    string? PayerDetail = null
);
