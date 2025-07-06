namespace BinancePayConnector.Services.Models.SubMerchant.Create;

public sealed record SubMerchantRestrictions(
    long? ContractTimeIsv = null,
    IEnumerable<string>? BlockPayerKycCountries = null
);