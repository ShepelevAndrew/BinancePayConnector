using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.Order.CloseOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.BuyerModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ShippingModel;
using BinancePayConnector.Models.C2B.RestApi.Order.PaymentPayerVerification;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryRefund;
using BinancePayConnector.Models.C2B.RestApi.Order.RefundOrder;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Services.Models.Result;
using BinancePayConnector.Services.Extensions;

namespace BinancePayConnector.Services;

public class BinancePayOrderService(
    IBinancePayClient client
) : IBinancePayOrderService
{
    // split into two (maybe) methods with fiat equivalent and crypto
    public async Task<BinancePayResult<CreateOrderResult>> CreateOrder(
        CreateOrder createOrder,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<CreateOrderResult, CreateOrder>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Order.CreateOrder,
                content: createOrder,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<CreateOrderResult>();
        }
    }

    public async Task<BinancePayResult<QueryOrderResult>> QueryOrder(
        string? prepayId = null,
        string? merchantTradeNo = null,
        CancellationToken ct = default)
    {
        var queryOrder = new QueryOrder(prepayId, merchantTradeNo);
        try
        {
            var response = await client.SendBinanceAsync<QueryOrderResult, QueryOrder>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Order.QueryOrder,
                content: queryOrder,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<QueryOrderResult>();
        }
    }

    public async Task<BinancePayResult<bool?>> CloseOrder(
        string? prepayId = null,
        string? merchantTradeNo = null,
        CancellationToken ct = default)
    {
        var closeOrder = new CloseOrder(prepayId, merchantTradeNo);
        try
        {
            var response = await client.SendBinanceAsync<bool?, CloseOrder>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Order.CloseOrder,
                content: closeOrder,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<bool?>();
        }
    }

    public async Task<BinancePayResult<RefundOrderResult>> RefundOrder(
        string refundRequestId,
        string prepayId,
        decimal refundAmount,
        string? refundReason = null,
        string? webhookUrl = null,
        CancellationToken ct = default)
    {
        var refundOrder = new RefundOrder(refundRequestId, prepayId, refundAmount, refundReason, webhookUrl);
        try
        {
            var response = await client.SendBinanceAsync<RefundOrderResult, RefundOrder>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Order.RefundOrder,
                content: refundOrder,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<RefundOrderResult>();
        }
    }

    public async Task<BinancePayResult<QueryRefundResult>> QueryRefund(
        string refundRequestId,
        CancellationToken ct = default)
    {
        var queryRefund = new QueryRefund(refundRequestId);
        try
        {
            var response = await client.SendBinanceAsync<QueryRefundResult, QueryRefund>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Order.QueryRefund,
                content: queryRefund,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<QueryRefundResult>();
        }
    }

    public async Task<BinancePayResult<bool?>> QueryPaymentPayerVerification(
        string binanceId,
        string payerType,
        List<Info>? information = null,
        CancellationToken ct = default)
    {
        var paymentPayerVerification = new PaymentPayerVerification(binanceId, payerType, information);
        try
        {
            var response = await client.SendBinanceAsync<bool?, PaymentPayerVerification>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Order.PaymentPayerVerification,
                content: paymentPayerVerification,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<bool?>();
        }
    }
}
