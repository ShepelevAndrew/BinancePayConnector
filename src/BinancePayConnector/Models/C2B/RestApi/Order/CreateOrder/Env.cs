using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;

/// <param name="TerminalType">
/// Terminal type of which the merchant service applies to. Valid values are: enum values from <see cref="Enums.TerminalType"/>.
/// </param>
/// <param name="OsType">
/// OS type. Valid values are: enum values from <see cref="Enums.OsType"/>.
/// </param>
/// <param name="OrderClientIp">
/// IP of the client device when submit the order.
/// </param>
/// <param name="CookieId">
/// The cookie ID of the buyer.
/// </param>
public sealed record Env(
    string TerminalType,
    string? OsType = null,
    string? OrderClientIp = null,
    string? CookieId = null
);
