namespace BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-create-v3#orderresult"/>
/// </summary>
public record CreateOrderResult(
    string PrepayId,
    string TerminalType,
    long ExpireTime,
    string QrcodeLink,
    string QrContent,
    string CheckoutUrl,
    string Deeplink,
    string UniversalUrl,
    string Currency,
    decimal TotalFee,
    string? FiatCurrency,
    decimal? FiatAmount
);
