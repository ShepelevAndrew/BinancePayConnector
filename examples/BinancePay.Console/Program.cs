using BinancePayConnector;
using BinancePayConnector.Helpers;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;

const string apiKey = "xz4t6ccz71826dprluewhkyc8of39iypbykadjx8qljfuy293nfsojtsid5zofwh";
const string apiSecret = "ishrrq2x8anvwh8yphuxbpivwacb32btk3xsmk6agtxtuvlur1hbydo63zo7bect";

var binancePay = new BinancePay(apiKey, apiSecret);

var response = await binancePay.Order.CreateOrder(
    request: new CreateOrder(
        Env: new Env(
            TerminalType: TerminalType.App
        ),
        MerchantTradeNo: IdentifierFactory.CreateBinanceId32(),
        OrderAmount: 0.001m,
        Currency: Assets.Usdt,
        Description: "Description",
        GoodsDetails:
        [
            new Goods(
                GoodsType: GoodsType.VirtualGoods,
                GoodsCategory: GoodsCategory.Others,
                ReferenceGoodsId: IdentifierFactory.CreateBinanceId32(),
                GoodsName: "Name"
            )
        ],
        OrderExpireTime: DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeMilliseconds(),
        WebhookUrl: "https://c056-188-163-49-145.ngrok-free.app/api/webhook/receive"));

if (response.IsFailure || response.Body is null)
{
    Console.WriteLine("Status code: " + response.StatusCode);
    Console.WriteLine("Binance status code: " + response.BinanceStatusCode);
    Console.WriteLine("Error message: " + response.ErrorMessage);

    return;
}

var order = await binancePay.Order.QueryOrder(response.Body.PrepayId);

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
