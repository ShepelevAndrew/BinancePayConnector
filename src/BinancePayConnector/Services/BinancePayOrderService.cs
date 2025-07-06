using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.Common.Enums;
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
using BinancePayConnector.Services.Models.Order.CreateOrder;

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

        var response = await client.SendBinanceAsync<CreateOrderResult, CreateOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CreateOrder,
            content: new CreateOrderRequest(
                Env: identification.Env,
                MerchantTradeNo: identification.MerchantTradeNo,
                AppId: identification.AppId,
                Description: details.Description,
                OrderAmount: details.OrderAmount,
                Currency: details.Currency,
                OrderExpireTime: orderExpireTimeMin,
                SupportPayCurrency: ToBinanceCurrencyString(details.SupportPayCurrency),
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
                FiatCurrency: null),
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

        var response = await client.SendBinanceAsync<CreateOrderResult, CreateOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CreateOrder,
            content: new CreateOrderRequest(
                Env: identification.Env,
                MerchantTradeNo: identification.MerchantTradeNo,
                AppId: identification.AppId,
                Description: details.Description,
                FiatAmount: details.FiatAmount,
                FiatCurrency: details.FiatCurrency,
                OrderExpireTime: orderExpireTimeMin,
                SupportPayCurrency: ToBinanceCurrencyString(details.SupportPayCurrency),
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
                Currency: null),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryOrderResult>> GetOrderByPrepayId(
        string prepayId,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryOrderResult, QueryOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.QueryOrder,
            content: new QueryOrderRequest(PrepayId: prepayId),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryOrderResult>> GetOrderByMerchantTradeNo(
        string merchantTradeNo,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryOrderResult, QueryOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.QueryOrder,
            content: new QueryOrderRequest(MerchantTradeNo: merchantTradeNo),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<bool?>> CloseOrderByPrepayId(
        string prepayId,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<bool?, CloseOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CloseOrder,
            content: new CloseOrderRequest(PrepayId: prepayId),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<bool?>> CloseOrderByMerchantTradeNo(
        string merchantTradeNo,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<bool?, CloseOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.CloseOrder,
            content: new CloseOrderRequest(MerchantTradeNo: merchantTradeNo),
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
        var response = await client.SendBinanceAsync<RefundOrderResult, RefundOrderRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.RefundOrder,
            content: new RefundOrderRequest(refundRequestId, prepayId, refundAmount, refundReason, webhookUrl),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryRefundResult>> GetRefund(
        string refundRequestId,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryRefundResult, QueryRefundRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.QueryRefund,
            content: new QueryRefundRequest(refundRequestId),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<bool?>> GetPaymentPayerVerification(
        string binanceId,
        string payerType,
        List<Info>? information = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<bool?, PaymentPayerVerificationRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Order.PaymentPayerVerification,
            content: new PaymentPayerVerificationRequest(binanceId, payerType, information),
            ct: ct);

        return response;
    }

    private static long? GetUnixTimestampAfterMinutes(long? minutes)
        => minutes is null
            ? null
            : DateTimeOffset.UtcNow.AddMinutes(minutes.Value).ToUnixTimeMilliseconds();

    private static string? ToBinanceCurrencyString(IEnumerable<AssetType>? assetTypes)
        => assetTypes != null
            ? string.Join(",", assetTypes.Select(a => a.ConvertToString()))
            : null;
}
