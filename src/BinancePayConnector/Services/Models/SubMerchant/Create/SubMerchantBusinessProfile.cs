namespace BinancePayConnector.Services.Models.SubMerchant.Create;

public sealed record SubMerchantBusinessProfile(
    string? Country = null,
    string? SiteUrl = null,
    string? Address = null,
    string? PayIndustryDescription = null,
    string? SubPayMccCode = null,
    string? SubPayIndustryDescription = null,
    string? BrandLogo = null
);