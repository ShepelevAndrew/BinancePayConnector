using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.QueryContract;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-directdebit-query-contract#request-parameters"/>.
/// </summary>
public sealed record QueryContractRequest(
    string? MerchantContractCode = null,
    long? ContractId = null
) : IRequest<QueryContractResult>;
