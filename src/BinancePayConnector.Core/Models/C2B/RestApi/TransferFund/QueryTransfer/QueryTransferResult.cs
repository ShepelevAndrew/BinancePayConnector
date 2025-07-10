using BinancePayConnector.Core.Models.C2B.RestApi.TransferFund.Common.Enums;

namespace BinancePayConnector.Core.Models.C2B.RestApi.TransferFund.QueryTransfer;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-wallet-transfer-query#transferresult"/>
/// </summary>
/// <param name="Status">Enum values from <see cref="QueryTransferStatus"/>.</param>
public sealed record QueryTransferResult(
    string TranId,
    string Status
);
