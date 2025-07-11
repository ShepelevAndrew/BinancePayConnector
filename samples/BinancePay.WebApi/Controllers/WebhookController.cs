﻿using BinancePayConnector;
using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.C2B.Webhook.Common;
using BinancePayConnector.Core.Models.C2B.Webhook.Common.Enums;
using BinancePayConnector.Core.Models.C2B.Webhook.Order;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BinancePay.WebApi.Controllers;

[ApiController]
[Route("api/webhooks")]
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

            var order = await binancePay.Order.GetOrderByPrepayId(
                prepayId: webhook.BizIdStr,
                ct: ct);
        }

        var response = new WebHookResponse(RequestStatus.Success);
        return Ok(response);
    }
}