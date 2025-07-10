namespace BinancePayConnector.Core.Models.C2B.RestApi.TechnicalServiceProvider.CreateAuthorizationRequest;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-technical-service-provider-create-record#dataobject"/>.
/// </summary>
public sealed record CreateAuthorizationResult(
    string AuthorizationId,
    string MerchantName,
    string AuthorizationToken,
    string MerchantId,
    string Status,
    string RedirectUrl,
    List<string> Scopes,
    List<string> IpWhitelist
);
