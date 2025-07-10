namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.ShippingModel;

public sealed record ShippingName(
    string FirstName,
    string LastName,
    string? MiddleName = null
);
