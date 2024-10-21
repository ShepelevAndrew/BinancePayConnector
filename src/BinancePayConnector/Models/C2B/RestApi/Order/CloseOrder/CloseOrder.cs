using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.Order.CloseOrder;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-close"/>
/// </summary>
public sealed record CloseOrder(
    string? PrepayId = null,
    string? MerchantTradeNo = null
) : ICommand<bool?>;
