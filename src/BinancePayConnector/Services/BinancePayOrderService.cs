using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.Order.CloseOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Models.C2B.RestApi.Order.PaymentPayerVerification;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryOrder.QueryOrderResultModel;
using BinancePayConnector.Models.C2B.RestApi.Order.QueryRefund;
using BinancePayConnector.Models.C2B.RestApi.Order.RefundOrder;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Services.Models.Order;

namespace BinancePayConnector.Services;

public class BinancePayOrderService(
    IBinancePayClient client
) : IBinancePayOrderService
{
    public async Task<BinancePayResult<CreateOrderResult>> CreateOrder(
        OrderIdentification identification,
        OrderDetailsCrypto details,
        IEnumerable<Goods> goods,
        OrderUrls? urls = null,
        OrderFeatures? features = null,
        OrderEntities? entities = null,
        CancellationToken ct = default)
    {
        var orderExpireTimeMin = GetUnixTimestampAfterMinutes(details.OrderExpireTimeMin);

        var createOrder = new CreateOrderRequest(
            Env: identification.Env,
            MerchantTradeNo: identification.MerchantTradeNo,
            AppId: identification.AppId,
            Description: details.Description,
            OrderAmount: details.OrderAmount,
            Currency: details.Currency,
            OrderExpireTime: orderExpireTimeMin,
            SupportPayCurrency: details.SupportPayCurrency,
            GoodsDetails: goods,
            ReturnUrl: urls?.ReturnUrl,
            CancelUrl: urls?.CancelUrl,
            WebhookUrl: urls?.WebhookUrl,
            UniversalUrlAttach: urls?.UniversalUrlAttach,
            PassThroughInfo: features?.PassThroughInfo,
            DirectDebitContract: features?.DirectDebitContract,
            OrderTags: features?.OrderTags,
            VoucherCode: features?.VoucherCode,
            Merchant: entities?.Merchant,
            Shipping: entities?.Shipping,
            Buyer: entities?.Buyer,
            FiatAmount: null,
            FiatCurrency: null);

        var response = await client.SendBinanceAsync<CreateOrderResult, CreateOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CreateOrder,
            content: createOrder,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<CreateOrderResult>> CreateOrder(
        OrderIdentification identification,
        OrderDetailsFiat details,
        IEnumerable<Goods> goods,
        OrderUrls? urls = null,
        OrderFeatures? features = null,
        OrderEntities? entities = null,
        CancellationToken ct = default)
    {
        var orderExpireTimeMin = GetUnixTimestampAfterMinutes(details.OrderExpireTimeMin);

        var createOrder = new CreateOrderRequest(
            Env: identification.Env,
            MerchantTradeNo: identification.MerchantTradeNo,
            AppId: identification.AppId,
            Description: details.Description,
            FiatAmount: details.FiatAmount,
            FiatCurrency: details.FiatCurrency,
            OrderExpireTime: orderExpireTimeMin,
            SupportPayCurrency: details.SupportPayCurrency,
            GoodsDetails: goods,
            ReturnUrl: urls?.ReturnUrl,
            CancelUrl: urls?.CancelUrl,
            WebhookUrl: urls?.WebhookUrl,
            UniversalUrlAttach: urls?.UniversalUrlAttach,
            PassThroughInfo: features?.PassThroughInfo,
            DirectDebitContract: features?.DirectDebitContract,
            OrderTags: features?.OrderTags,
            VoucherCode: features?.VoucherCode,
            Merchant: entities?.Merchant,
            Shipping: entities?.Shipping,
            Buyer: entities?.Buyer,
            OrderAmount: null,
            Currency: null);

        var response = await client.SendBinanceAsync<CreateOrderResult, CreateOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CreateOrder,
            content: createOrder,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryOrderResult>> QueryOrderByPrepayId(
        string prepayId,
        CancellationToken ct = default)
    {
        var queryOrder = new QueryOrderRequest(PrepayId: prepayId);
        var response = await client.SendBinanceAsync<QueryOrderResult, QueryOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.QueryOrder,
            content: queryOrder,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryOrderResult>> QueryOrderByMerchantTradeNo(
        string merchantTradeNo,
        CancellationToken ct = default)
    {
        var queryOrder = new QueryOrderRequest(MerchantTradeNo: merchantTradeNo);
        var response = await client.SendBinanceAsync<QueryOrderResult, QueryOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.QueryOrder,
            content: queryOrder,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<bool?>> CloseOrderByPrepayId(
        string prepayId,
        CancellationToken ct = default)
    {
        var closeOrder = new CloseOrderRequest(PrepayId: prepayId);
        var response = await client.SendBinanceAsync<bool?, CloseOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CloseOrder,
            content: closeOrder,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<bool?>> CloseOrderByMerchantTradeNo(
        string merchantTradeNo,
        CancellationToken ct = default)
    {
        var closeOrder = new CloseOrderRequest(MerchantTradeNo: merchantTradeNo);
        var response = await client.SendBinanceAsync<bool?, CloseOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CloseOrder,
            content: closeOrder,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<RefundOrderResult>> RefundOrder(
        string refundRequestId,
        string prepayId,
        decimal refundAmount,
        string? refundReason = null,
        string? webhookUrl = null,
        CancellationToken ct = default)
    {
        var refundOrder = new RefundOrderRequest(refundRequestId, prepayId, refundAmount, refundReason, webhookUrl);
        var response = await client.SendBinanceAsync<RefundOrderResult, RefundOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.RefundOrder,
            content: refundOrder,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryRefundResult>> QueryRefund(
        string refundRequestId,
        CancellationToken ct = default)
    {
        var queryRefund = new QueryRefundRequest(refundRequestId);
        var response = await client.SendBinanceAsync<QueryRefundResult, QueryRefundRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.QueryRefund,
            content: queryRefund,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<bool?>> QueryPaymentPayerVerification(
        string binanceId,
        string payerType,
        List<Info>? information = null,
        CancellationToken ct = default)
    {
        var paymentPayerVerification = new PaymentPayerVerificationRequest(binanceId, payerType, information);
        var response = await client.SendBinanceAsync<bool?, PaymentPayerVerificationRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.PaymentPayerVerification,
            content: paymentPayerVerification,
            ct: ct);

        return response;
    }

    private static long? GetUnixTimestampAfterMinutes(long? minutes)
        => minutes is null
            ? null
            : DateTimeOffset.UtcNow.AddMinutes(minutes.Value).ToUnixTimeMilliseconds();
}
