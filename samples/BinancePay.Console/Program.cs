using BinancePayConnector;
using BinancePayConnector.Core.Config.Options;
using BinancePayConnector.Core.Domain;
using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Models.Order.CreateOrder;

const string apiKey = "api-key";
const string apiSecret = "api-secret";

var binancePay = new BinancePay(apiKey, apiSecret)
{
    WebhookConfig = new BinancePayWebhookConfig
    {
        BaseUri = "http://localhost:4421"
    }
};

var response = await binancePay.Order.CreateOrder(
    identification: new OrderIdentification(
        Env: new Env(TerminalType.App),
        MerchantTradeNo: BinancePayId.Generate32().Value
    ),
    details: new OrderDetailsCrypto(
        Description: "Description",
        OrderAmount: 0.001m,
        Currency: Assets.Usdt,
        OrderExpireTimeMin: 5
    ),
    goods: [
        new Goods(
            GoodsType.VirtualGoods,
            GoodsCategory.Others,
            ReferenceGoodsId: BinancePayId.Generate32().Value,
            GoodsName: "Name")
    ],
    urls: new OrderUrls(
        WebhookUrl: "https://localhost:4142/api/binancepay/webhooks/order",
        ReturnUrl: "https://test.com/return",
        CancelUrl: "https://test.com/cancel"
    )
);

if (response.IsFailure || response.Body is null)
{
    Console.WriteLine("Status code: " + response.StatusCode);
    Console.WriteLine("Binance status code: " + response.BinanceStatusCode);
    Console.WriteLine("Error message: " + response.ErrorMessage);

    return;
}

var order = await binancePay.Order.GetOrderByPrepayId(response.Body.PrepayId);

Console.WriteLine("Status: " + order.Body?.Status);
Console.WriteLine("PrepayId: " + response.Body.PrepayId);
Console.WriteLine("Amount: " + response.Body.TotalFee);
Console.WriteLine("Currency: " + response.Body.Currency);
Console.WriteLine("Deep link: " + response.Body.Deeplink);
Console.WriteLine("Universal url: " + response.Body.UniversalUrl);
Console.WriteLine("Qr-code image: " + response.Body.QrcodeLink);

binancePay.OnUpdateInvoke(request =>
{
    Console.WriteLine(request.BizId);
    Console.WriteLine(request.BizStatus);
    Console.WriteLine(request.Data);
});

Console.WriteLine("Press any key to stop...");
Console.ReadKey();

await binancePay.StopReceiving();

Console.ReadKey();
