using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.SubMerchant.Common;
using BinancePayConnector.Core.Models.C2B.RestApi.SubMerchant.ModifySubMerchant;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.SubMerchant;

public class ModifySubMerchantHandler(
    IBinancePayClient client
) : IRequestHandler<ModifySubMerchantRequest, AddSubMerchantResult>
{
    public async Task<BinancePayResult<AddSubMerchantResult>> ExecuteAsync(
        ModifySubMerchantRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<AddSubMerchantResult, ModifySubMerchantRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.SubMerchant.ModifySubMerchant,
            content: command,
            ct: ct);

        return response;
    }
}