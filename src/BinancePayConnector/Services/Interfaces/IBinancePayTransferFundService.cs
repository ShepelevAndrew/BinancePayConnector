using BinancePayConnector.Models.C2B.RestApi.TransferFund.QueryTransfer;
using BinancePayConnector.Models.C2B.RestApi.TransferFund.TransferFund;
using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayTransferFundService
{
    Task<BinancePayResult<TransferFundResult>> TransferFund(
        TransferFund request,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryTransferResult>> QueryTransferResult(
        QueryTransfer request,
        CancellationToken ct = default);
}
