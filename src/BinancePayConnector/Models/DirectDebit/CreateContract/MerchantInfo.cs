namespace BinancePayConnector.Models.DirectDebit.CreateContract;

public sealed record MerchantInfo(
    string? SubMerchantId = null,
    string? MerchantAccountNo = null
);