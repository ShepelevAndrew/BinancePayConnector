using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.TransferFund.QueryTransfer;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-wallet-transfer-query#request-parameters"/>
/// </summary>
public sealed record QueryTransfer(
    string TranId
) : ICommand<QueryTransferResult>;
