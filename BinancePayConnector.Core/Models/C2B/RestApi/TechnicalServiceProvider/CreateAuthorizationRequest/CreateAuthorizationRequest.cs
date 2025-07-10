using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.TechnicalServiceProvider.CreateAuthorizationRequest;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-technical-service-provider-create-record#request-parameters"/>.
/// </summary>
public sealed record CreateAuthorizationRequest(
    string MerchantId,
    List<string> Scopes,
    List<string> IpWhitelist
) : IRequest<CreateAuthorizationResult>;
