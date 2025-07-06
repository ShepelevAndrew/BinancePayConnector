namespace BinancePayConnector.Services.Models.DirectDebit;

public sealed record MerchantContractIdentification(
    string MerchantContractCode,
    string ServiceName
);