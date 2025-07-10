using BinancePayConnector.Core.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;
using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.QueryOrder;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-query-v2"/>
/// </summary>
public record QueryOrderRequest(
    string? PrepayId = null,
    string? MerchantTradeNo = null
) : IRequest<QueryOrderResult>;
