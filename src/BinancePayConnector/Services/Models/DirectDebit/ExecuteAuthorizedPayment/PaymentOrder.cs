using BinancePayConnector.Models.C2B.Common.Enums;

namespace BinancePayConnector.Services.Models.DirectDebit.ExecuteAuthorizedPayment;

public sealed record PaymentOrder(
    decimal Amount,
    string Currency = Assets.Usdt,
    string TradeMode = "DIRECT_DEBIT"
);