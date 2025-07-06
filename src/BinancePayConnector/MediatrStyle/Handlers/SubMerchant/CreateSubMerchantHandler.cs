using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.Common;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.CreateSubMerchant;

namespace BinancePayConnector.MediatrStyle.Handlers.SubMerchant;

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