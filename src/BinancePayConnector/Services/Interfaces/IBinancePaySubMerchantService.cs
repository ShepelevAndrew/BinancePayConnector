using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Models.C2B.RestApi.SubMerchant.Common;
using BinancePayConnector.Models.SubMerchant.Create;

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
