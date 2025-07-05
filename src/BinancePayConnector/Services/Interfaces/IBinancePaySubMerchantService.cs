using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.Common;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.CreateSubMerchant;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.ModifySubMerchant;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePaySubMerchantService
{
    Task<BinancePayResult<AddSubMerchantResult>> CreateSubMerchant(
        CreateSubMerchant request,
        CancellationToken ct = default);

    Task<BinancePayResult<AddSubMerchantResult>> ModifySubMerchant(
        ModifySubMerchant request,
        CancellationToken ct = default);
}
