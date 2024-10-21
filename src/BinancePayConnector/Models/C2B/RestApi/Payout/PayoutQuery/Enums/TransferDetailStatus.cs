namespace BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery.Enums;

public static class TransferDetailStatus
{
    /// <summary>
    /// Money has been transferred successfully.
    /// </summary>
    public const string Success = "SUCCESS";

    /// <summary>
    /// Transaction failed, may be caused by insufficient funds in your account.
    /// </summary>
    public const string Fail = "FAIL";

    /// <summary>
    /// Pending: new user needs to create a Binance account and pass KYC to receive money.
    /// </summary>
    public const string AwaitingReceipt = "AWAITING_RECEIPT";

    /// <summary>
    /// Refunded: new user hasn’t passed KYC in 72 hours.
    /// </summary>
    public const string Refunded = "REFUNDED";
}
