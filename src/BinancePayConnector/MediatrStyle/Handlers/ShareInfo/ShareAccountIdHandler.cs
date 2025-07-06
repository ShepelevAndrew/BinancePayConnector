using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.ShareInfo.ShareAccoutId;

namespace BinancePayConnector.MediatrStyle.Handlers.ShareInfo;

public class ShareAccountIdHandler(
    IBinancePayClient client
) : IRequestHandler<ShareAccountIdRequest, ShareAccountIdResult>
{
    public async Task<BinancePayResult<ShareAccountIdResult>> ExecuteAsync(
        ShareAccountIdRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<ShareAccountIdResult, ShareAccountIdRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.ShareInfo.ShareAccountId,
            content: command,
            ct: ct);

        return response;
    }
}