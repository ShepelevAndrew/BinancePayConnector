using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.SubMerchant.Common;
using BinancePayConnector.Services.Models.SubMerchant.Create;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePaySubMerchantService
{
    Task<BinancePayResult<AddSubMerchantResult>> CreateSubMerchant(
        SubMerchantBasicInfo basicInfo,
        SubMerchantBusinessProfile? businessProfile = null,
        SubMerchantRegistration? registration = null,
        SubMerchantCertificate? certificate = null,
        SubMerchantRestrictions? restrictions = null,
        CancellationToken ct = default);

    Task<BinancePayResult<AddSubMerchantResult>> ModifySubMerchant(
        string subMerchantId,
        SubMerchantBasicInfo basicInfo,
        SubMerchantBusinessProfile? businessProfile = null,
        SubMerchantRegistration? registration = null,
        SubMerchantCertificate? certificate = null,
        SubMerchantRestrictions? restrictions = null,
        CancellationToken ct = default);
}
