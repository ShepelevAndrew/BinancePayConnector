using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.AddReceiver;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.DeleteReceiver;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.QueryReceiver;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.QuerySplit;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.SplitReturn;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.SubmitSplit;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayProfitSharingService
{
    Task<BinancePayResult<AddReceiverResult>> AddReceiver(
        AddReceiver request,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryReceiverResult>> QueryReceiver(
        QueryReceiver request,
        CancellationToken ct = default);

    Task<BinancePayResult<DeleteReceiverResult>> DeleteReceiver(
        DeleteReceiver request,
        CancellationToken ct = default);

    Task<BinancePayResult<SubmitSplitResult>> SubmitSplit(
        SubmitSplit request,
        CancellationToken ct = default);

    Task<BinancePayResult<QuerySplitResult>> QuerySplit(
        QuerySplit request,
        CancellationToken ct = default);

    Task<BinancePayResult<SplitReturnResult>> SplitReturn(
        SplitReturn request,
        CancellationToken ct = default);
}
