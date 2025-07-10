using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.Enums;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.ShippingModel;

/// <param name="Region">The 2-letter country/region code. For more information, see ISO 3166 Country Codes standard.</param>
/// <param name="State">The state, country, or province name.</param>
/// <param name="City">The city, district, suburb, town, or village name.</param>
/// <param name="Address">Address, for example, the stress address/PO box/company name.</param>
/// <param name="ZipCode">ZIP or postal code.</param>
/// <param name="ShippingAddressType">Shipping to: enum values from <see cref="Enums.ShippingAddressType"/>.</param>
public sealed record ShippingAddress(
    string Region,
    string? State = null,
    string? City = null,
    string? Address = null,
    string? ZipCode = null,
    string? ShippingAddressType = null
);
