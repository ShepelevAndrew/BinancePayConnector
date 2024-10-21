namespace BinancePayConnector.Models.C2B.RestApi.Payout.BatchPayout.Enums;

public static class BizSceneType
{
    /// <summary>
    /// DIRECT_TRANSFER: the default value
    /// </summary>
    public const string DirectTransfer = "DIRECT_TRANSFER";

    /// <summary>
    /// CRYPTO_REWARDS: gift or rewards payout
    /// </summary>
    public const string CryptoRewards = "CRYPTO_REWARDS";

    /// <summary>
    /// SETTLEMENT: settlement or commission fee
    /// </summary>
    public const string Settlement = "SETTLEMENT";

    /// <summary>
    /// REIMBURSEMENT: reimburse employees
    /// </summary>
    public const string Reimbursement = "REIMBURSEMENT";

    /// <summary>
    /// MERCHANT_PAYMENT: payment to partners/users
    /// </summary>
    public const string MerchantPayment = "MERCHANT_PAYMENT";

    /// <summary>
    /// OTHERS
    /// </summary>
    public const string Others = "OTHERS";
}
