using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.SplitReturn;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-split-return#request-parameters"/>.
/// </summary>
public sealed record SplitReturnRequest(
    string PrepayOrderId,
    string MerchantReturnNo,
    string TransferOutAccount,
    decimal ReturnAmount,
    string? SplitOrderNo = null,
    string? OriginMerchantRequestId = null,
    string? Description = null,
    string? WebhookUrl = null
) : IRequest<SplitReturnResult>;
