namespace BinancePayConnector.Models.C2B.Webhook.Common;

/// <summary>
/// Default Binance Pay Api WebHookRequest.
/// </summary>
/// <param name="BizType">Depends on Binance Pay Api Service. Enum values from: <see cref="Enums.BizType"/>.</param>
/// <param name="BizId">Depends on <see cref="Enums.BizType"/>.</param>
/// <param name="BizIdStr">Biz id as string.</param>
/// <param name="BizStatus">Depends on <see cref="Enums.BizType"/>.
/// Enum values from: <see cref="Enums.BizStatus"/>.
/// </param>
/// <param name="Data">Json as string. Different data, depends on <see cref="Enums.BizType"/>.</param>
public sealed record WebHookRequest(
    string BizType,
    long BizId,
    string BizIdStr,
    string BizStatus,
    string Data
);
