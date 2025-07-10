using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.TerminateContract;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-directdebit-terminate-contract"/>.
/// </summary>
public sealed record TerminateContractRequest(
    string? MerchantContractCode = null,
    long? ContractId = null,
    string? TerminationNotes = null
) : IRequest<bool?>;
