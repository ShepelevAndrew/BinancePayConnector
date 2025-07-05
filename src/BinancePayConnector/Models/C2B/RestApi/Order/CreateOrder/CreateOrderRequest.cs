using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.BuyerModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.Enums;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ResultModel;
using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder.ShippingModel;

namespace BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-create-v3#request-parameters"/>.
/// </summary>
/// <param name="Env">System environment.</param>
/// <param name="MerchantTradeNo">The order id.</param>
/// <param name="Description">Goods description in the checkout page.</param>
/// <param name="OrderAmount">When currency is not null. Minimum amount: 0.00000001.</param>
/// <param name="Currency">Currency and fiatCurrency cannot be both null. Enum values from <see cref="Assets"/>.</param>
/// <param name="FiatAmount">Minimum amount: 0.00000001.</param>
/// <param name="FiatCurrency">Currency and fiatCurrency cannot be both null. Enum values from <see cref="Assets"/>.</param>
/// <param name="ReturnUrl">The URL to redirect to when the payment is successful.</param>
/// <param name="CancelUrl">The URL to redirect to when payment is failed.</param>
/// <param name="OrderExpireTime">Please input in milliseconds.</param>
/// <param name="SupportPayCurrency">Input to be separated by commas, e.g. USDT,BNB.</param>
/// <param name="AppId">This field is required when terminalType is <see cref="TerminalType.MiniProgram"/>.</param>
/// <param name="UniversalUrlAttach">The attachment parameter for the response field universalUrl.</param>
/// <param name="PassThroughInfo">Pass through info, returned as-is in query order API and payment webhook notification.</param>
/// <param name="WebhookUrl">The URL for order notification, can only start with http or https.</param>
/// <param name="DirectDebitContract">Use this function order currency can only accept USDT.</param>
/// <param name="OrderTags">Object to tag order for specific features such as profit sharing.</param>
public sealed record CreateOrderRequest(
    Env Env,
    string MerchantTradeNo,
    string Description,
    IEnumerable<Goods> GoodsDetails,
    Merchant? Merchant = null,
    decimal? OrderAmount = null,
    string? Currency = null,
    decimal? FiatAmount = null,
    string? FiatCurrency = null,
    Shipping? Shipping = null,
    Buyer? Buyer = null,
    string? ReturnUrl = null,
    string? CancelUrl = null,
    long? OrderExpireTime = null,
    string? SupportPayCurrency = null,
    string? AppId = null,
    string? UniversalUrlAttach = null,
    string? PassThroughInfo = null,
    string? WebhookUrl = null,
    DirectDebitContract? DirectDebitContract = null,
    OrderTags? OrderTags = null,
    string? VoucherCode = null
) : IRequest<CreateOrderResult>;
