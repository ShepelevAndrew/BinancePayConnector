using BinancePayConnector.Core.Models.C2B.Webhook.TechServiceProvider.Enums;

namespace BinancePayConnector.Core.Models.C2B.Webhook.TechServiceProvider;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/webhook-tech-service-provider#notification-data"/>.
/// </summary>
/// <param name="Scopes">Enum values from: <see cref="ScopeType"/>.</param>
public record TechServiceProviderNotification(
    string AuthorizationId,
    string AuthorizationToken,
    long MerchantId,
    string MerchantName,
    List<string>? Scopes
);
