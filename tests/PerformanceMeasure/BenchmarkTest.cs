using BenchmarkDotNet.Attributes;
using BinancePayConnector;
using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Config.Options;
using BinancePayConnector.Domain;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Services.Models.Order.CreateOrder;

namespace PerformanceMeasure;

[MemoryDiagnoser]
public class BenchmarkTest
{
    private const string ApiKey = "api-key";
    private const string ApiSecret = "api-secret";

    [Benchmark]
    public async Task<BinancePayResult<CreateOrderResult>> BinancePay_CreateOrder()
    {
        var binancePay = new BinancePay(ApiKey, ApiSecret);

        var response = await binancePay.Order.CreateOrder(
            identification: new OrderIdentification(
                new Env(TerminalType.App),
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
                    GoodsType: GoodsType.VirtualGoods,
                    GoodsCategory: GoodsCategory.Others,
                    ReferenceGoodsId: BinancePayId.Generate32().Value,
                    GoodsName: "Name")
            ],
            urls: new OrderUrls(
                WebhookUrl: "https://localhost:4142/api/binancepay/webhooks/order",
                ReturnUrl: "https://test.com/return",
                CancelUrl: "https://test.com/cancel"
            )
        );

        return response;
    }

    [Benchmark]
    public async Task<BinancePayResult<CreateOrderResult>> BinancePaySlim_CreateOrder()
    {
        var binancePaySlim = new BinancePaySlim(ApiKey, ApiSecret);

        var response = await binancePaySlim.Send(
            request: GetCreateOrderCommand());

        return response;
    }

    [Benchmark]
    public async Task<BinancePayResult<CreateOrderResult>> BinancePayClient_CreateOrder()
    {
        var binancePayClient = new BinancePayClient(ApiKey, ApiSecret);

        var response = await binancePayClient.SendBinanceAsync<CreateOrderResult, CreateOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CreateOrder,
            content: GetCreateOrderCommand());

        return response;
    }

    [Benchmark]
    public async Task<BinancePayResult<CreateOrderResult>> BinancePay_WithReceiver_CreateOrder()
    {
        var binancePay = new BinancePay(ApiKey, ApiSecret)
        {
            WebhookConfig = new BinancePayWebhookConfig
            {
                BaseUri = "http://localhost:4421"
            }
        };

        var response = await binancePay.Order.CreateOrder(
            identification: new OrderIdentification(
                new Env(TerminalType.App),
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
                    GoodsType: GoodsType.VirtualGoods,
                    GoodsCategory: GoodsCategory.Others,
                    ReferenceGoodsId: BinancePayId.Generate32().Value,
                    GoodsName: "Name")
            ],
            urls: new OrderUrls(
                WebhookUrl: "https://localhost:4142/api/binancepay/webhooks/order",
                ReturnUrl: "https://test.com/return",
                CancelUrl: "https://test.com/cancel"
            )
        );

        return response;
    }

    [Benchmark]
    public async Task<BinancePayResult<CreateOrderResult>> BinancePaySlim_WithReceiver_CreateOrder()
    {
        var binancePaySlim = new BinancePaySlim(ApiKey, ApiSecret)
        {
            WebhookConfig = new BinancePayWebhookConfig
            {
                BaseUri = "http://localhost:4421"
            }
        };

        var response = await binancePaySlim.Send(
            request: GetCreateOrderCommand());

        return response;
    }

    private static CreateOrderRequest GetCreateOrderCommand()
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
            WebhookUrl: "https://c056-188-163-49-145.ngrok-free.app/api/webhook/receive"
        );
}