using BinancePayConnector;
using BinancePayConnector.Domain;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Services.Models.Order.CreateOrder;
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
}