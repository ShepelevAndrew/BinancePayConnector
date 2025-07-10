using BinancePayConnector.Core.Models.C2B.RestApi.SubMerchant.Common;
using BinancePayConnector.Core.Models.C2B.RestApi.SubMerchant.Common.Enums;
using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.SubMerchant.CreateSubMerchant;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-submerchant-add#request-parameters"/>
/// </summary>
/// <param name="MerchantName">The sub merchant name.</param>
/// <param name="StoreType">You can convert int value to enum <see cref="Common.Enums.StoreType"/>.</param>
/// <param name="MerchantMcc">Four-digit number that classifies the business. Enum values from <see cref="MccCode"/>.</param>
/// <param name="MerchantType">You can convert int value to enum <see cref="Common.Enums.MerchantType"/>.</param>
/// <param name="Country">Country/Region of Business Operation,Can be multiple, split by "," eg:"SG,US".</param>
/// <param name="SiteUrl">For Online stores, the URL field is required.</param>
/// <param name="Address">For Physical stores, the address field is required.</param>
/// <param name="PayIndustryDescription">Mandatory if merchantMcc is <see cref="MccCode.Other"/>.</param>
/// <param name="SubPayMccCode">Enum values from <see cref="MccCode"/>.</param>
/// <param name="SubPayIndustryDescription">Mandatory if subPayMccCode is <see cref="MccCode.Other"/>.</param>
/// <param name="BrandLogo">Sub merchant logo url</param>
/// <param name="CompanyName">The legal name that is used in the registration.</param>
/// <param name="RegistrationNumber">Registration number/Company tax ID.</param>
/// <param name="IncorporationDate">The date when the business registration is in effective.</param>
/// <param name="CertificateType">You can convert int value to enum <see cref="Enums.CertificateType"/>.</param>
/// <param name="ContractTimeIsv">Contract date with ISV.</param>
/// <param name="BlockPayerKycCountries">Blocks payers from specified countries based on their KYC country. The list contains the countries to be blocked.</param>
public sealed record CreateSubMerchantRequest(
    string MerchantName,
    int StoreType,
    string MerchantMcc,
    int? MerchantType = null,
    string? Country = null,
    string? SiteUrl = null,
    string? Address = null,
    string? PayIndustryDescription = null,
    string? SubPayMccCode = null,
    string? SubPayIndustryDescription = null,
    string? BrandLogo = null,
    string? CompanyName = null,
    string? RegistrationNumber = null,
    string? RegistrationCountry = null,
    string? RegistrationAddress = null,
    long? IncorporationDate = null,
    int? CertificateType = null,
    string? CertificateCountry = null,
    string? CertificateNumber = null,
    long? CertificateValidDate = null,
    long? ContractTimeIsv = null,
    IEnumerable<string>? BlockPayerKycCountries = null
) : IRequest<AddSubMerchantResult>;
