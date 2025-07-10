using BinancePayConnector.Core.Models.C2B.Common.Enums;

namespace BinancePayConnector.Models.DirectDebit.ExecuteAuthorizedPayment;

public sealed record PaymentOrder(
    decimal Amount,
    string Currency = Assets.Usdt,
    string TradeMode = "DIRECT_DEBIT"
);