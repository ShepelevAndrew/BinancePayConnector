using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.DirectDebit.CreateContract;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-directdebit-create-contract#request-parameters"/>.
/// </summary>
/// <param name="MerchantContractCode">The unique ID assigned by the merchant to identify a direct debit contract request. letter or digit, no other symbol allowed.</param>
/// <param name="ScenarioCode">Scenario code. Enum values from <see cref="Order.CreateOrder.Enums.ScenarioCode"/></param>
/// <param name="SingleUpperLimit">Upper limit related to scenarioCode.</param>
/// <param name="Periodic">This contract support periodic debit or not.</param>
/// <param name="CycleDebitFixed">Mandatory if periodic = true. true = fixed amount, false = variable amount.</param>
/// <param name="CycleType">Mandatory if periodic = true. Values: MONTH or DAY</param>
/// <param name="CycleValue">Mandatory if periodic = true.</param>
/// <param name="FirstDeductTime">Mandatory if periodic = true. first deduct time, must be a future time in milliseconds.</param>
/// <param name="MerchantAccountNo">The userID/user account in merchant side e.g. xxx@gmail.com</param>
/// <param name="ContractEndTime">	If not specified, contractEndTime will be the time after 1095 days (about 3 years). maximum is 1095 days in milliseconds.</param>
public sealed record CreateContract(
    string MerchantContractCode,
    string ServiceName,
    string ScenarioCode,
    decimal SingleUpperLimit,
    string Currency,
    bool Periodic,
    string? SubMerchantId = null,
    bool? CycleDebitFixed = null,
    string? CycleType = null,
    int? CycleValue = null,
    long? FirstDeductTime = null,
    string? MerchantAccountNo = null,
    long? RequestExpireTime = null,
    long? ContractEndTime = null
) : ICommand<CreateContractResult>;
