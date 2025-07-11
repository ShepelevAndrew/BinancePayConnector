using BenchmarkDotNet.Attributes;
using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Config.Options;
using BinancePayConnector.Core.Domain;
using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Models.Order.CreateOrder;

using BinancePayConnectorSlim;

namespace BinancePayConnector.Benchmarks;

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
            request: GetCreateOrderRequest());

        return response;
    }

    [Benchmark]
    public async Task<BinancePayResult<CreateOrderResult>> BinancePayClient_CreateOrder()
    {
        var binancePayClient = new BinancePayClient(ApiKey, ApiSecret);

        var response = await binancePayClient.SendBinanceAsync<CreateOrderResult, CreateOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CreateOrder,
            content: GetCreateOrderRequest());

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
            request: GetCreateOrderRequest());

        return response;
    }

    private static CreateOrderRequest GetCreateOrderRequest()
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