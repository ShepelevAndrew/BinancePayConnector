using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.ShareInfo.ShareAccoutId;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-shareinfo-account-id#request-parameters"/>.
/// </summary>
public sealed record ShareAccountIdRequest(
    string RequestId,
    string? SubMerchantId = null,
    string? WebhookUrl = null
) : IRequest<ShareAccountIdResult>;
