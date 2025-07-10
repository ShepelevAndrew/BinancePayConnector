using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Models.C2B.RestApi.TransferFund.QueryTransfer;
using BinancePayConnector.Core.Models.C2B.RestApi.TransferFund.TransferFund;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayTransferFundService
{
    Task<BinancePayResult<TransferFundResult>> FundTransfer(
        string requestId,
        string currency,
        string amount,
        string transferType,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryTransferResult>> GetTransferResult(
        string tranId,
        CancellationToken ct = default);
}
