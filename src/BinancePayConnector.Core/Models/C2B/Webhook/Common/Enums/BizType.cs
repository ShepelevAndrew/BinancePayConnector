namespace BinancePayConnector.Core.Models.C2B.Webhook.Common.Enums;

public static class BizType
{
    public const string Order = "PAY";
    public const string Payout = "PAYOUT";
    public const string PayoutNonBinanceUser = "PAYOUT_NON_BN";
    public const string RefundOrder = "PAY_REFUND";
    public const string Balance = "BALANCE";
    public const string DirectDebit = "DIRECT_DEBIT_CT";
    public const string TechServiceProvider = "TECH_PROVIDER";
    public const string ShareAccountId = "SHARE_ACCOUNT_ID";
}
