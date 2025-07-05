using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.Common;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.CreateSubMerchant;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.ModifySubMerchant;
using BinancePayConnector.Services.Interfaces;

namespace BinancePayConnector.Services;

public class BinancePaySubMerchantService(
    IBinancePayClient client
) : IBinancePaySubMerchantService
{
    public async Task<BinancePayResult<AddSubMerchantResult>> CreateSubMerchant(
        CreateSubMerchant request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<AddSubMerchantResult, CreateSubMerchant>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.SubMerchant.CreateSubMerchant,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<AddSubMerchantResult>> ModifySubMerchant(
        ModifySubMerchant request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<AddSubMerchantResult, ModifySubMerchant>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.SubMerchant.ModifySubMerchant,
            content: request,
            ct: ct);

        return response;
    }
}
