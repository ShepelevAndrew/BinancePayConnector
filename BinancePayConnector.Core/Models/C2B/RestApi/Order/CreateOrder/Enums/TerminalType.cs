namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.Enums;

public static class TerminalType
{
    /// <summary>
    /// The client-side terminal type is a mobile application.
    /// </summary>
    public const string App = "APP";

    /// <summary>
    /// The client-side terminal type is a website that is opened via a PC browser
    /// </summary>
    public const string Web = "WEB";

    /// <summary>
    /// The client-side terminal type is an HTML page that is opened via a mobile browser.
    /// </summary>
    public const string Wap = "WAP";

    /// <summary>
    /// The terminal type of the merchant side is a mini program on the mobile phone.
    /// </summary>
    public const string MiniProgram = "MINI_PROGRAM";

    public const string PaymentLink = "PAYMENT_LINK";

    /// <summary>
    /// Other undefined type
    /// </summary>
    public const string Others = "OTHERS";
}
