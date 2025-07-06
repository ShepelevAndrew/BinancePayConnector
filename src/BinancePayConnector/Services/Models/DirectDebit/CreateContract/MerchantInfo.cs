namespace BinancePayConnector.Services.Models.DirectDebit;

public sealed record MerchantInfo(
    string? SubMerchantId = null,
    string? MerchantAccountNo = null
);