using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Models.C2B.RestApi.Order.PaymentPayerVerification;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryRefund;
using BinancePayConnector.Models.C2B.RestApi.Order.RefundOrder;
using BinancePayConnector.Services.Models.Order.CreateOrder;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayOrderService
{
    Task<BinancePayResult<CreateOrderResult>> CreateOrder(
        OrderIdentification identification,
        OrderDetailsCrypto details,
        IEnumerable<Goods> goods,
        OrderUrls? urls = null,
        OrderFeatures? features = null,
        OrderEntities? entities = null,
        CancellationToken ct = default);

    Task<BinancePayResult<CreateOrderResult>> CreateOrder(
        OrderIdentification identification,
        OrderDetailsFiat details,
        IEnumerable<Goods> goods,
        OrderUrls? urls = null,
        OrderFeatures? features = null,
        OrderEntities? entities = null,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryOrderResult>> GetOrderByPrepayId(
        string prepayId,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryOrderResult>> GetOrderByMerchantTradeNo(
        string merchantTradeNo,
        CancellationToken ct = default);

    Task<BinancePayResult<bool?>> CloseOrderByPrepayId(
        string prepayId,
        CancellationToken ct = default);

    Task<BinancePayResult<bool?>> CloseOrderByMerchantTradeNo(
        string merchantTradeNo,
        CancellationToken ct = default);

    Task<BinancePayResult<RefundOrderResult>> RefundOrder(
        string refundRequestId,
        string prepayId,
        decimal refundAmount,
        string? refundReason = null,
        string? webhookUrl = null,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryRefundResult>> GetRefund(
        string refundRequestId,
        CancellationToken ct = default);

    Task<BinancePayResult<bool?>> GetPaymentPayerVerification(
        string binanceId,
        string payerType,
        List<Info>? information = null,
        CancellationToken ct = default);
}
