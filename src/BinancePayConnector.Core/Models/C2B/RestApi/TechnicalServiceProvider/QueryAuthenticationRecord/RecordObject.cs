namespace BinancePayConnector.Core.Models.C2B.RestApi.TechnicalServiceProvider.QueryAuthenticationRecord;

public sealed record RecordObject(
    string AuthorizationId,
    string MerchantName,
    string AuthorizationToken,
    string MerchantId,
    string Status,
    List<string> Scopes,
    List<string> IpWhitelist
);
