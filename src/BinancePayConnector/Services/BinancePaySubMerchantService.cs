using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.SubMerchant.Common;
using BinancePayConnector.Core.Models.C2B.RestApi.SubMerchant.CreateSubMerchant;
using BinancePayConnector.Core.Models.C2B.RestApi.SubMerchant.ModifySubMerchant;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Models.SubMerchant.Create;

namespace BinancePayConnector.Services;

public class BinancePaySubMerchantService(
    IBinancePayClient client
) : IBinancePaySubMerchantService
{
    public async Task<BinancePayResult<AddSubMerchantResult>> CreateSubMerchant(
        SubMerchantBasicInfo basicInfo,
        SubMerchantBusinessProfile? businessProfile = null,
        SubMerchantRegistration? registration = null,
        SubMerchantCertificate? certificate = null,
        SubMerchantRestrictions? restrictions = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<AddSubMerchantResult, CreateSubMerchantRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.SubMerchant.CreateSubMerchant,
            content: new CreateSubMerchantRequest(
                MerchantName: basicInfo.MerchantName,
                StoreType: basicInfo.StoreType,
                MerchantMcc: basicInfo.MerchantMcc,
                MerchantType: basicInfo.MerchantType,
                Country: businessProfile?.Country,
                SiteUrl: businessProfile?.SiteUrl,
                Address: businessProfile?.Address,
                PayIndustryDescription: businessProfile?.PayIndustryDescription,
                SubPayMccCode: businessProfile?.SubPayMccCode,
                SubPayIndustryDescription: businessProfile?.SubPayIndustryDescription,
                BrandLogo: businessProfile?.BrandLogo,
                CompanyName: registration?.CompanyName,
                RegistrationNumber: registration?.RegistrationNumber,
                RegistrationCountry: registration?.RegistrationCountry,
                RegistrationAddress: registration?.RegistrationAddress,
                IncorporationDate: registration?.IncorporationDate,
                CertificateType: certificate?.CertificateType,
                CertificateCountry: certificate?.CertificateCountry,
                CertificateNumber: certificate?.CertificateNumber,
                CertificateValidDate: certificate?.CertificateValidDate,
                ContractTimeIsv: restrictions?.ContractTimeIsv,
                BlockPayerKycCountries: restrictions?.BlockPayerKycCountries),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<AddSubMerchantResult>> ModifySubMerchant(
        string subMerchantId,
        SubMerchantBasicInfo basicInfo,
        SubMerchantBusinessProfile? businessProfile = null,
        SubMerchantRegistration? registration = null,
        SubMerchantCertificate? certificate = null,
        SubMerchantRestrictions? restrictions = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<AddSubMerchantResult, ModifySubMerchantRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.SubMerchant.ModifySubMerchant,
            content: new ModifySubMerchantRequest(
                SubMerchantId: subMerchantId,
                MerchantName: basicInfo.MerchantName,
                StoreType: basicInfo.StoreType,
                MerchantMcc: basicInfo.MerchantMcc,
                MerchantType: basicInfo.MerchantType,
                Country: businessProfile?.Country,
                SiteUrl: businessProfile?.SiteUrl,
                Address: businessProfile?.Address,
                PayIndustryDescription: businessProfile?.PayIndustryDescription,
                SubPayMccCode: businessProfile?.SubPayMccCode,
                SubPayIndustryDescription: businessProfile?.SubPayIndustryDescription,
                BrandLogo: businessProfile?.BrandLogo,
                CompanyName: registration?.CompanyName,
                RegistrationNumber: registration?.RegistrationNumber,
                RegistrationCountry: registration?.RegistrationCountry,
                RegistrationAddress: registration?.RegistrationAddress,
                IncorporationDate: registration?.IncorporationDate,
                CertificateType: certificate?.CertificateType,
                CertificateCountry: certificate?.CertificateCountry,
                CertificateNumber: certificate?.CertificateNumber,
                CertificateValidDate: certificate?.CertificateValidDate,
                ContractTimeIsv: restrictions?.ContractTimeIsv,
                BlockPayerKycCountries: restrictions?.BlockPayerKycCountries),
            ct: ct);

        return response;
    }
}
