using BinancePayConnector.Models.C2B.RestApi.TransferFund.Common.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.TransferFund.TransferFund;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-wallet-transfer#transferresult"/>.
/// </summary>
/// <param name="TranId">The value of Request property requestId.</param>
/// <param name="Status">Enum values from: <see cref="QueryTransferStatus"/>.</param>
public sealed record TransferFundResult(
    string TranId,
    string Status,
    string Currency,
    string Amount,
    string TransferType
);
