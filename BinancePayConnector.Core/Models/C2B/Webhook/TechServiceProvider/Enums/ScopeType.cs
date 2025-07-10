namespace BinancePayConnector.Core.Models.C2B.Webhook.TechServiceProvider.Enums;

public static class ScopeType
{
    /// <summary>
    /// All convert APIs.
    /// </summary>
    public const string Convert = "CONVERT";

    /// <summary>
    /// Refund order api.
    /// </summary>
    public const string Refund = "REFUND";

    /// <summary>
    /// All order related APIs except refund order api.
    /// </summary>
    public const string Checkout = "CHECKOUT";

    /// <summary>
    /// All payout related APIs.
    /// </summary>
    public const string Payout = "PAYOUT";

    /// <summary>
    /// All reporting related APIs.
    /// </summary>
    public const string Report = "REPORT";

    /// <summary>
    /// All transfer fund related APIs.
    /// </summary>
    public const string InternalTransfer = "INTERNAL_TRANSFER";

    /// <summary>
    /// All wallet balance related APIs.
    /// </summary>
    public const string Balance = "BALANCE";
}
