using BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutQuery.Enums;

namespace BinancePayConnector.Core.Models.C2B.Webhook.Common.Enums;

public static class BizStatus
{
    public static class OrderBizStatus
    {
        public const string PaySuccess = "PAY_SUCCESS";
        public const string PayClosed = "PAY_Closed";
    }

    /// <summary>
    /// Same as <see cref="BatchStatus"/>.
    /// </summary>
    public static class PayoutBizStatus
    {
        public const string Accepted = BatchStatus.Accepted;
        public const string Processing = BatchStatus.Processing;
        public const string Success = BatchStatus.Success;
        public const string PartSuccess = BatchStatus.PartSuccess;
        public const string Failed = BatchStatus.Failed;
        public const string Canceled = BatchStatus.Canceled;
    }

    /// <summary>
    /// Same as <see cref="TransferDetailStatus"/>.
    /// </summary>
    public static class PayoutNonBinanceUserBizStatus
    {
        public const string Success = TransferDetailStatus.Success;
        public const string Fail = TransferDetailStatus.Fail;
        public const string AwaitingReceipt = TransferDetailStatus.AwaitingReceipt;
        public const string Refunded = TransferDetailStatus.Refunded;
    }

    public static class RefundOrderBizStatus
    {
        public const string RefundSuccess = "REFUND_SUCCESS";
        public const string RefundReject = "REFUND_REJECT";
    }

    public static class BalanceReportBizStatus
    {
        public const string BalanceSuccess = "BALANCE_SUCCESS";
    }

    public static class DirectDebitBizStatus
    {
        public const string ContractSigned = "CONTRACT_SIGNED";
        public const string ContractTerminated = "CONTRACT_TERMINATED";
    }

    public static class TechServiceProviderBizStatus
    {
        public const string SubmitAuthAgree = "SUBMIT_AUTH_AGREE";
        public const string SubmitAuthReject = "SUBMIT_AUTH_REJECT";
        public const string TpAuthChanged = "TP_AUTH_CHANGED";
        public const string TpAuthDisable = "TP_AUTH_DISABLED";
    }

    public static class ShareAccountIdBizStatus
    {
        public const string Success = "SUCCESS";
    }
}
