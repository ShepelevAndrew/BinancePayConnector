using BenchmarkDotNet.Attributes;
using BinancePayConnector;
using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Config.Options;
using BinancePayConnector.Helpers;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Services.Extensions;
using BinancePayConnector.Services.Models.Result;

namespace PerformanceMeasure;

[MemoryDiagnoser]
public class BenchmarkTest
{
    private const string ApiKey = "xz4t6ccz71826dprluewhkyc8of39iypbykadjx8qljfuy293nfsojtsid5zofwh";
    private const string ApiSecret = "ishrrq2x8anvwh8yphuxbpivwacb32btk3xsmk6agtxtuvlur1hbydo63zo7bect";

    [Benchmark]
    public async Task<BinancePayResult<CreateOrderResult>> BinancePay_CreateOrder()
    {
        var binancePay = new BinancePay(ApiKey, ApiSecret);

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
                WebhookUrl: "https://c056-188-163-49-145.ngrok-free.app/api/webhook/receive"));;

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
        try
        {
            var binancePayClient = new BinancePayClient(ApiKey, ApiSecret);

            var response = await binancePayClient.SendBinanceAsync<CreateOrderResult, CreateOrder>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Order.CreateOrder,
                content: GetCreateOrderCommand());

            return response.AsBinancePayResult();
        }
        catch(BinancePayRequestException e)
        {
            return e.AsBinancePayResult<CreateOrderResult>();
        }
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
                WebhookUrl: "https://c056-188-163-49-145.ngrok-free.app/api/webhook/receive"));;

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

    private static CreateOrder GetCreateOrderCommand()
        => new(
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
            WebhookUrl: "https://c056-188-163-49-145.ngrok-free.app/api/webhook/receive"
        );
}