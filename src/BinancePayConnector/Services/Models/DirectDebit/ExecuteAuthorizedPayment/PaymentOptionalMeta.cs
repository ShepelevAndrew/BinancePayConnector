using BinancePayConnector.Models.C2B.RestApi.DirectDebit.Payment;

namespace BinancePayConnector.Services.Models.DirectDebit.ExecuteAuthorizedPayment;

public sealed record PaymentOptionalMeta(
    string? SubMerchantId = null,
    long? PreBizId = null,
    string? WebhookUrl = null,
    OrderTag? OrderTags = null
);