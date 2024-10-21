namespace BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.BuyerModel;

/// <param name="ReferenceBuyerId">
/// Restrict specific Binance ID to make payment. Only whitelisted merchant can use this restriction feature.
/// </param>
/// <param name="BuyerName">Name of buyer full name from merchants.</param>
/// <param name="BuyerPhoneNo">Mobile phone number of the buyer from merchants.</param>
/// <param name="BuyerEmail">Email of the buyer from merchants.</param>
/// <param name="BuyerRegistrationTime">Buyer registration time on merchant side, epoch time milliseconds.</param>
/// <param name="BuyerBrowserLanguage">The language of the merchant's platform shows the buyer.</param>
public sealed record Buyer(
    string? ReferenceBuyerId = null,
    BuyerName? BuyerName = null,
    string? BuyerPhoneCountryCode = null,
    string? BuyerPhoneNo = null,
    string? BuyerEmail = null,
    long? BuyerRegistrationTime = null,
    string? BuyerBrowserLanguage = null
);
