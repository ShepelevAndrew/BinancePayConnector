using BinancePayConnector.Models.C2B.Common.Enums;

namespace BinancePayConnector.Models.C2B.Webhook.DirectDebit;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/webhook-directdebit-contract#notification-data"/>.
/// </summary>
/// <param name="MerchantContractCode">The unique ID assigned by the merchant to identify a direct debit contract request.</param>
/// <param name="Currency">Enum values from: <see cref="Assets"/>.</param>
/// <param name="OpenUserId">Payer unique id.</param>
/// <param name="MerchantAccountNo">The userID/user account in merchant side.</param>
/// <param name="ContractTerminationWay">Only "CONTRACT_TERMINATED" status. Can convert int to enum value: <see cref="RestApi.DirectDebit.QueryContract.Enums.ContractTerminationWay"/>.</param>
/// <param name="ContractTerminationTime">Only "CONTRACT_TERMINATED" status</param>
public sealed record DirectDebitNotification(
    string MerchantContractCode,
    long ContractId,
    string ServiceName,
    decimal SingleUpperLimit,
    string Currency,
    string? OpenUserId,
    string? MerchantAccountNo,
    int? ContractTerminationWay,
    long? ContractTerminationTime
);
