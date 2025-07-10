using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.AddReceiver;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.DeleteReceiver;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.QueryReceiver;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.QuerySplit;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.SplitReturn;
using BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.SubmitSplit;
using BinancePayConnector.Models.ProfitSharing.GetSplitInfo;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayProfitSharingService
{
    Task<BinancePayResult<AddReceiverResult>> AddReceiver(
        string account,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryReceiverResult>> GetReceiver(
        int pageNum,
        int pageSize,
        CancellationToken ct = default);

    Task<BinancePayResult<DeleteReceiverResult>> DeleteReceiver(
        string account,
        CancellationToken ct = default);

    Task<BinancePayResult<SubmitSplitResult>> SubmitSplit(
        string merchantRequestId,
        string prepayOrderId,
        IEnumerable<Receiver> receiverList,
        CancellationToken ct = default);

    Task<BinancePayResult<QuerySplitResult>> GetSplit(
        string merchantRequestId,
        string prepayOrderId,
        CancellationToken ct = default);

    Task<BinancePayResult<SplitReturnResult>> GetSplitInfo(
        SplitIdentification identification,
        SplitTransfer transfer,
        SplitMeta? meta = null,
        CancellationToken ct = default);
}
