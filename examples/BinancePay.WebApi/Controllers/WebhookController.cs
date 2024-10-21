using BinancePayConnector;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder;
using BinancePayConnector.Models.C2B.Webhook.Common;
using BinancePayConnector.Models.C2B.Webhook.Common.Enums;
using BinancePayConnector.Models.C2B.Webhook.Order;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BinancePay.WebApi.Controllers;

[ApiController]
[Route("api/webhook")]
public class WebhookController(IBinancePay binancePay) : ControllerBase
{
    [HttpPost]
    [Route("receive")]
    public async Task<ActionResult<WebHookResponse>> ReceiveWebHook(
        WebHookRequest webhook,
        CancellationToken ct)
    {
        if (webhook.BizType == BizType.Order)
        {
            var orderNotification = JsonConvert.DeserializeObject<OrderNotification>(webhook.Data);

            var order = await binancePay.Order.QueryOrder(
                prepayId: webhook.BizIdStr,
                ct: ct);
        }

        var response = new WebHookResponse(RequestStatus.Success);
        return Ok(response);
    }
}