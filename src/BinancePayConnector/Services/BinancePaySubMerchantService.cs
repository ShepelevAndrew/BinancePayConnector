using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.Common;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.CreateSubMerchant;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.ModifySubMerchant;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Services.Models.Result;
using BinancePayConnector.Services.Extensions;

namespace BinancePayConnector.Services;

public class BinancePaySubMerchantService(
    IBinancePayClient client)
        : IBinancePaySubMerchantService
{
    public async Task<BinancePayResult<AddSubMerchantResult>> CreateSubMerchant(
        CreateSubMerchant request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<AddSubMerchantResult, CreateSubMerchant>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.SubMerchant.CreateSubMerchant,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<AddSubMerchantResult>();
        }
    }

    public async Task<BinancePayResult<AddSubMerchantResult>> ModifySubMerchant(
        ModifySubMerchant request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<AddSubMerchantResult, ModifySubMerchant>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.SubMerchant.ModifySubMerchant,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<AddSubMerchantResult>();
        }
    }
}
