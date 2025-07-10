using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.TransferFund.QueryTransfer;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-wallet-transfer-query#request-parameters"/>
/// </summary>
public sealed record QueryTransferRequest(
    string TranId
) : IRequest<QueryTransferResult>;
