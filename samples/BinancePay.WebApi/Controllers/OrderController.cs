using BinancePayConnector;
using BinancePayConnector.Core.Domain;
using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Models.Order.CreateOrder;
using BinancePayConnectorSlim;
using Microsoft.AspNetCore.Mvc;

namespace BinancePay.WebApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(
    IBinancePay binancePay,
    IBinancePaySlim binancePaySlim
) : ControllerBase
{
    [HttpPost]
    [Route("new")]
    public async Task<ActionResult<CreateOrderResult>> CreateOrder(
        CancellationToken ct)
    {
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
            ),
            ct: ct);

        return response.IsSuccess
            ? Ok(response.Body)
            : BadRequest(new
            {
                Status = response.StatusCode,
                BinanceStatusCode = response.BinanceStatusCode,
                ErrorMessage = response.ErrorMessage
            });
    }

    [HttpPost]
    [Route("new/slim")]
    public async Task<ActionResult<CreateOrderResult>> CreateOrderSlim(
        CancellationToken ct)
    {
        var response = await binancePaySlim.Send(
            request: new CreateOrderRequest(
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
                WebhookUrl: "https://96b4-188-163-49-145.ngrok-free.app/api/binancepay/webhooks/order",
                ReturnUrl: "https://test.com/return",
                CancelUrl: "https://test.com/cancel"
            ),
            ct: ct
        );

        return response.IsSuccess
            ? Ok(response.Body)
            : BadRequest(new
            {
                Status = response.StatusCode,
                BinanceStatusCode = response.BinanceStatusCode,
                ErrorMessage = response.ErrorMessage
            });
    }
}