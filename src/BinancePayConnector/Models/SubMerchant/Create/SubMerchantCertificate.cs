namespace BinancePayConnector.Models.SubMerchant.Create;

public sealed record SubMerchantCertificate(
    int? CertificateType = null,
    string? CertificateCountry = null,
    string? CertificateNumber = null,
    long? CertificateValidDate = null
);