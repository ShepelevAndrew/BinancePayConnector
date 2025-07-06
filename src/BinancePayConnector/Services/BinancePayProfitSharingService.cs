using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.AddReceiver;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.DeleteReceiver;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.QueryReceiver;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.QuerySplit;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.SplitReturn;
using BinancePayConnector.Models.C2B.RestApi.ProfitSharing.SubmitSplit;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Services.Models.ProfitSharing.GetSplitInfo;

namespace BinancePayConnector.Services;

public class BinancePayProfitSharingService(
    IBinancePayClient client
) : IBinancePayProfitSharingService
{
    public async Task<BinancePayResult<AddReceiverResult>> AddReceiver(
        string account,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<AddReceiverResult, AddReceiverRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.AddReceiver,
            content: new AddReceiverRequest(account),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryReceiverResult>> GetReceiver(
        int pageNum,
        int pageSize,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryReceiverResult, QueryReceiverRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.QueryReceiver,
            content: new QueryReceiverRequest(pageNum, pageSize),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<DeleteReceiverResult>> DeleteReceiver(
        string account,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<DeleteReceiverResult, DeleteReceiverRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.DeleteReceiver,
            content: new DeleteReceiverRequest(account),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<SubmitSplitResult>> SubmitSplit(
        string merchantRequestId,
        string prepayOrderId,
        IEnumerable<Receiver> receiverList,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<SubmitSplitResult, SubmitSplitRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.SubmitSplit,
            content: new SubmitSplitRequest(merchantRequestId, prepayOrderId, receiverList),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QuerySplitResult>> GetSplit(
        string merchantRequestId,
        string prepayOrderId,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QuerySplitResult, QuerySplitRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.QuerySplit,
            content: new QuerySplitRequest(merchantRequestId, prepayOrderId),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<SplitReturnResult>> GetSplitInfo(
        SplitIdentification identification,
        SplitTransfer transfer,
        SplitMeta? meta = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<SplitReturnResult, SplitReturnRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.SplitReturn,
            content: new SplitReturnRequest(
                PrepayOrderId: identification.PrepayOrderId,
                MerchantReturnNo: identification.MerchantReturnNo,
                TransferOutAccount: transfer.TransferOutAccount,
                ReturnAmount: transfer.ReturnAmount,
                SplitOrderNo: meta?.SplitOrderNo,
                OriginMerchantRequestId: meta?.OriginMerchantRequestId,
                Description: meta?.Description,
                WebhookUrl: meta?.WebhookUrl),
            ct: ct);

        return response;
    }
}
