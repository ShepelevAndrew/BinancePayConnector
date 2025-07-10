using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.SubMerchant.Common;
using BinancePayConnector.Core.Models.C2B.RestApi.SubMerchant.CreateSubMerchant;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.SubMerchant;

public class CreateSubMerchantHandler(
    IBinancePayClient client
) : IRequestHandler<CreateSubMerchantRequest, AddSubMerchantResult>
{
    public async Task<BinancePayResult<AddSubMerchantResult>> ExecuteAsync(
        CreateSubMerchantRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<AddSubMerchantResult, CreateSubMerchantRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.SubMerchant.CreateSubMerchant,
            content: command,
            ct: ct);

        return response;
    }
}