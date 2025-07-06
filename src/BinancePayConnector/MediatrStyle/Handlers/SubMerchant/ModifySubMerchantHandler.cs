using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.Common;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.ModifySubMerchant;

namespace BinancePayConnector.MediatrStyle.Handlers.SubMerchant;

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