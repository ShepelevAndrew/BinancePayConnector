namespace BinancePayConnector.Core.Models.C2B.RestApi.TechnicalServiceProvider.GetRequestRecord;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-technical-service-provider-get-record#dataobject"/>.
/// </summary>
public sealed record GetRequestRecordResult(
    string AuthorizationId,
    string MerchantName,
    string AuthorizationToken,
    string MerchantId,
    string Status,
    List<string> Scopes,
    List<string> IpWhitelist
);
