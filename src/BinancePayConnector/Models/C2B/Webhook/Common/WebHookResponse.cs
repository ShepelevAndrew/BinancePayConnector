using BinancePayConnector.Models.C2B.Common.Enums;

namespace BinancePayConnector.Models.C2B.Webhook.Common;

/// <summary>
/// After receiving a webhook with your endpoint, please respond with an HTTP 200 OK.
/// </summary>
/// <param name="ReturnCode">
/// Result code of notification processing, if process fail, Binance Pay will retry.
/// Enum values from <see cref="RequestStatus"/>.
/// </param>
public record WebHookResponse(
    string ReturnCode,
    string? ReturnMessage = null
);
