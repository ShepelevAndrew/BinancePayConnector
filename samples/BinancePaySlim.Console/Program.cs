using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Options;
using BinancePayConnector.Core.Domain;
using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.QueryOrder;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;
using BinancePayConnector.Core.Models.C2B.Webhook.BalanceReport;
using BinancePayConnector.Core.Models.C2B.Webhook.Common;
using BinancePayConnector.Core.Models.C2B.Webhook.Common.Enums;
using BinancePayConnector.Core.Models.C2B.Webhook.Order;
using BinancePayConnectorSlim;
using Newtonsoft.Json;

const string apiKey = "api-key";
const string apiSecret = "api-secret";

var binancePay = new BinancePaySlim(apiKey, apiSecret)
{
    WebhookConfig = new BinancePayWebhookConfig
    {
        BaseUri = "http://localhost:4421"
    }
};

var result = await binancePay.Send(request: CreateOrder());

if (result.IsFailure || result.Body is null)
{
    PrintError(result); return;
}

var orderResult = await binancePay.Send(request: GetOrder(result.Body.PrepayId));

PrintOrder(result.Body, orderResult.Body);

binancePay.OnUpdateInvoke(request =>
{
    if (request.BizType is BizType.Order) return;
    var orderNotification = DeserializeJson<OrderNotification>(request.Data);

    PrintOrderNotification(request, orderNotification);
});

binancePay.OnUpdateInvoke(request =>
{
    if (request.BizType is not BizType.Order) return;
    var orderNotification = DeserializeJson<OrderNotification>(request.Data);

    PrintOrderNotification(request, orderNotification);
}, "api/binancepay/webhooks/order");

binancePay.OnUpdateInvoke(request =>
{
    if (request.BizType is not BizType.Balance) return ResponseType.Failure;
    var balanceReportNotification = DeserializeJson<BalanceReportNotification>(request.Data);

    PrintBalanceNotification(request, balanceReportNotification);
    return ResponseType.Success;
}, "api/binancepay/webhooks/direct-debit");

PressKeyToStop("Press any key to stop receiving...");

await binancePay.StopReceiving();

PressKeyToStop("Press any key to stop application...");

return;

CreateOrderRequest CreateOrder()
    => new(
        Env: new Env(
            TerminalType: TerminalType.App
        ),
        MerchantTradeNo: BinancePayId.Generate32().Value,
        OrderAmount: 0.001m,
        Currency: Assets.Usdt,
        Description: "Description",
        GoodsDetails:
        [
            new Goods(
                GoodsType: GoodsType.VirtualGoods,
                GoodsCategory: GoodsCategory.Others,
                ReferenceGoodsId: BinancePayId.Generate32().Value,
                GoodsName: "Name"
            )
        ],
        OrderExpireTime: DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeMilliseconds(),
        WebhookUrl: "https://96b4-188-163-49-145.ngrok-free.app/api/binancepay/webhooks/order"
    );

QueryOrderRequest GetOrder(string prepayId) => new(PrepayId: prepayId);

TData DeserializeJson<TData>(string json)
    => JsonConvert.DeserializeObject<TData>(json)
       ?? throw new ArgumentException("Invalid request data");

void PrintError<T>(BinancePayResult<T> binanceResult)
{
    Console.WriteLine("Status code: " + binanceResult.StatusCode);
    Console.WriteLine("Binance status code: " + binanceResult.BinanceStatusCode);
    Console.WriteLine("Error message: " + binanceResult.ErrorMessage);
}

void PrintOrder(CreateOrderResult createResult, QueryOrderResult? order)
{
    Console.WriteLine("Status: " + order?.Status);
    Console.WriteLine("PrepayId: " + createResult.PrepayId);
    Console.WriteLine("Amount: " + createResult.TotalFee);
    Console.WriteLine("Currency: " + createResult.Currency);
    Console.WriteLine("Deep link: " + createResult.Deeplink);
    Console.WriteLine("Universal url: " + createResult.UniversalUrl);
    Console.WriteLine("Qr-code image: " + createResult.QrcodeLink);
}

void PrintOrderNotification(WebHookRequest request, OrderNotification notification)
{
    Console.WriteLine("Webhook info:");
    Console.WriteLine("\t" + request.BizId);
    Console.WriteLine("\t" + request.BizType);
    Console.WriteLine("\t" + request.BizStatus);
    Console.WriteLine("\nWebhook data:\n{");
    Console.WriteLine("\t" + notification.MerchantTradeNo);
    Console.WriteLine("\t" + notification.TotalFee);
    Console.WriteLine("\t" + notification.Currency);
    Console.WriteLine("}");
}

void PrintBalanceNotification(WebHookRequest request, BalanceReportNotification notification)
{
    Console.WriteLine("Webhook info:");
    Console.WriteLine("\t" + request.BizId);
    Console.WriteLine("\t" + request.BizType);
    Console.WriteLine("\t" + request.BizStatus);
    Console.WriteLine("\nWebhook data:\n{");
    Console.WriteLine("\t" + notification.Status);
    Console.WriteLine("\t" + notification.DownloadType);
    Console.WriteLine("\t" + notification.DownloadLink);
    Console.WriteLine("}");
}

void PressKeyToStop(string message)
{
    Console.WriteLine(message);
    Console.ReadKey();
}