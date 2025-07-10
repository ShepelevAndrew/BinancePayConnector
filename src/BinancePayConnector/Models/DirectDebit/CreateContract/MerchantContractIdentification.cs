namespace BinancePayConnector.Models.DirectDebit.CreateContract;

public sealed record MerchantContractIdentification(
    string MerchantContractCode,
    string ServiceName
);