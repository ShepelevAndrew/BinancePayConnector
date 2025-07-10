namespace BinancePayConnector.Core.Models.C2B.Webhook.RefundOrder;

public sealed record RefundInfo(
    string RefundRequestId,
    string PrepayId,
    string OrderAmount,
    string RefundedAmount,
    string RefundAmount,
    int RemainingAttempts,
    string PayerOpenId,
    string DuplicateRequest
);
