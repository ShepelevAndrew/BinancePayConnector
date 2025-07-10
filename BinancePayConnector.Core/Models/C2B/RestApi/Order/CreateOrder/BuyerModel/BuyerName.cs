namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.BuyerModel;

public sealed record BuyerName(
    string FirstName,
    string LastName,
    string? MiddleName = null
);
