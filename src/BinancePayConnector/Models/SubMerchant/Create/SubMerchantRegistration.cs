namespace BinancePayConnector.Models.SubMerchant.Create;

public sealed record SubMerchantRegistration(
    string? CompanyName = null,
    string? RegistrationNumber = null,
    string? RegistrationCountry = null,
    string? RegistrationAddress = null,
    long? IncorporationDate = null
);