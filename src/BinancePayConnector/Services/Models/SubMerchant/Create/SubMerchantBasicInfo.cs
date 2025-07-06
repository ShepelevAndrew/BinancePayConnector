namespace BinancePayConnector.Services.Models.SubMerchant.Create;

public sealed record SubMerchantBasicInfo(
    string MerchantName,
    int StoreType,
    string MerchantMcc,
    int? MerchantType = null
);