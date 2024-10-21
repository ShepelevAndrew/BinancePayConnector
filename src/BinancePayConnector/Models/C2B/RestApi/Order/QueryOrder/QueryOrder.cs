using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;

namespace BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-query-v2"/>
/// </summary>
public record QueryOrder(
    string? PrepayId = null,
    string? MerchantTradeNo = null
) : ICommand<QueryOrderResult>;
