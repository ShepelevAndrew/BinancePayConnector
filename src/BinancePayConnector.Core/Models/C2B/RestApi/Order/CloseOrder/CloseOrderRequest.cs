﻿using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.CloseOrder;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-close"/>
/// </summary>
public sealed record CloseOrderRequest(
    string? PrepayId = null,
    string? MerchantTradeNo = null
) : IRequest<bool?>;
