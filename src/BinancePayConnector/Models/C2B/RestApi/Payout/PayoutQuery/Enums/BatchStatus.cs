namespace BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery.Enums;

public static class BatchStatus
{
    /// <summary>
    /// Accepted: accepted the request, will process it soon.
    /// </summary>
    public const string Accepted = "ACCEPTED";

    /// <summary>
    /// Processing: batch under processing.
    /// </summary>
    public const string Processing = "PROCESSING";

    /// <summary>
    /// Success: All payout performed successfully, user have received fund in Binance funding wallet.
    /// </summary>
    public const string Success = "SUCCESS";

    /// <summary>
    /// Part success: transfers partially succeeded.
    /// Reasons:
    /// 1. Insufficient funds: there’s insufficient fund in your account.
    /// 2. Awaiting recipient: pending user to create Binance account and perform KYC.
    /// 3. Partial refund: user failed to complete KYC in 72 hours, fund will be funded to merchant account.
    /// </summary>
    public const string PartSuccess = "PART_SUCCESS";

    /// <summary>
    /// Failed: all transfers failed.
    /// </summary>
    public const string Failed = "FAILED";

    /// <summary>
    /// Canceled: Transfer request canceled by Binance due to unknown system errors after retry limit, will not retry further.
    /// </summary>
    public const string Canceled = "CANCELED";
}
