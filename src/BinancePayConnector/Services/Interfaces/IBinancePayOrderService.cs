using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.BuyerModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ShippingModel;
using BinancePayConnector.Models.C2B.RestApi.Order.PaymentPayerVerification;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryRefund;
using BinancePayConnector.Models.C2B.RestApi.Order.RefundOrder;
using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayOrderService
{
    Task<BinancePayResult<CreateOrderResult>> CreateOrder(
        CreateOrder request,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryOrderResult>> QueryOrder(
        string? prepayId = null,
        string? merchantTradeNo = null,
        CancellationToken ct = default);

    Task<BinancePayResult<bool?>> CloseOrder(
        string? prepayId = null,
        string? merchantTradeNo = null,
        CancellationToken ct = default);

    Task<BinancePayResult<RefundOrderResult>> RefundOrder(
        string refundRequestId,
        string prepayId,
        decimal refundAmount,
        string? refundReason = null,
        string? webhookUrl = null,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryRefundResult>> QueryRefund(
        string refundRequestId,
        CancellationToken ct = default);

    Task<BinancePayResult<bool?>> QueryPaymentPayerVerification(
        string binanceId,
        string payerType,
        List<Info>? information = null,
        CancellationToken ct = default);
}
