namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.ShippingModel;

/// <param name="ShippingName">The recipient name.</param>
/// <param name="ShippingAddress">Shipping address.</param>
/// <param name="ShippingPhoneNo">The phone number of a recipient (including extension).</param>
public sealed record Shipping(
    ShippingName? ShippingName = null,
    ShippingAddress? ShippingAddress = null,
    string? ShippingPhoneNo = null
);
