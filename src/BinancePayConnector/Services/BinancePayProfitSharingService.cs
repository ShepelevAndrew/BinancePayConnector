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

namespace BinancePayConnector.Services;

public class BinancePayProfitSharingService(
    IBinancePayClient client
) : IBinancePayProfitSharingService
{
    public async Task<BinancePayResult<AddReceiverResult>> AddReceiver(
        AddReceiver request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<AddReceiverResult, AddReceiver>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.AddReceiver,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryReceiverResult>> QueryReceiver(
        QueryReceiver request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryReceiverResult, QueryReceiver>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.QueryReceiver,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<DeleteReceiverResult>> DeleteReceiver(
        DeleteReceiver request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<DeleteReceiverResult, DeleteReceiver>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.DeleteReceiver,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<SubmitSplitResult>> SubmitSplit(
        SubmitSplit request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<SubmitSplitResult, SubmitSplit>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.SubmitSplit,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QuerySplitResult>> QuerySplit(
        QuerySplit request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QuerySplitResult, QuerySplit>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.QuerySplit,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<SplitReturnResult>> SplitReturn(
        SplitReturn request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<SplitReturnResult, SplitReturn>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ProfitSharing.SplitReturn,
            content: request,
            ct: ct);

        return response;
    }
}
