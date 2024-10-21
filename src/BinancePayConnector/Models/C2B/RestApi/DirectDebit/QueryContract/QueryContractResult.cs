using BinancePayConnector.Models.C2B.RestApi.DirectDebit.Common.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.DirectDebit.QueryContract;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-directdebit-query-contract#querycontractresult"/>.
/// </summary>
/// <param name="BizStatus">Contract status. Enum vaules from: <see cref="Common.Enums.BizStatus"/>.</param>
/// <param name="ContractTerminationWay">Only if "CONTRACT_TERMINATED" status. You can convert int value into enum <see cref="Enums.ContractTerminationWay"/>.</param>
public sealed record QueryContractResult(
    string BizStatus,
    string MerchantContractCode,
    string ServiceName,
    decimal SingleUpperLimit,
    string Currency,
    long? ContractId = null,
    string? OpenUserId = null,
    string? MerchantAccountNo = null,
    int? ContractTerminationWay = null,
    long? ContractTerminationTime = null
);
