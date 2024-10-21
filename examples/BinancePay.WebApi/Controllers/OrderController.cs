using BinancePayConnector;
using BinancePayConnector.Helpers;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using Microsoft.AspNetCore.Mvc;

namespace BinancePay.WebApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(
    IBinancePay binancePay
) : ControllerBase
{
    [HttpPost]
    [Route("new")]
    public async Task<ActionResult<CreateOrderResult>> CreateOrder(
        CancellationToken ct)
    {
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