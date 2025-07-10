using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.Enums;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder;

/// <param name="MerchantContractCode">The unique ID assigned by the merchant to identify a direct debit contract request. letter or digit, no other symbol allowed.</param>
/// <param name="ScenarioCode">Scenario code. Enum values from <see cref="Enums.ScenarioCode"/></param>
/// <param name="SingleUpperLimit">Upper limit related to scenarioCode.</param>
/// <param name="Periodic">This contract support periodic debit or not.</param>
/// <param name="CycleDebitFixed">Mandatory if periodic = true. true = fixed amount, false = variable amount.</param>
/// <param name="CycleType">Mandatory if periodic = true. Values: MONTH or DAY</param>
/// <param name="CycleValue">Mandatory if periodic = true.</param>
/// <param name="FirstDeductTime">Mandatory if periodic = true. first deduct time, must be a future time in milliseconds.</param>
/// <param name="MerchantAccountNo">The userID/user account in merchant side e.g. xxx@gmail.com</param>
/// <param name="ContractEndTime">	If not specified, contractEndTime will be the time after 1095 days (about 3 years). maximum is 1095 days in milliseconds.</param>
public sealed record DirectDebitContract(
    string MerchantContractCode,
    string ServiceName,
    string ScenarioCode,
    decimal SingleUpperLimit,
    bool Periodic,
    bool? CycleDebitFixed = null,
    string? CycleType = null,
    int? CycleValue = null,
    long? FirstDeductTime = null,
    string? MerchantAccountNo = null,
    long? ContractEndTime = null
);