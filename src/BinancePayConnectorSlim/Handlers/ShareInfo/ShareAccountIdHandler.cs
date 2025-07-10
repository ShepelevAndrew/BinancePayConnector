using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.ShareInfo.ShareAccoutId;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.ShareInfo;

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