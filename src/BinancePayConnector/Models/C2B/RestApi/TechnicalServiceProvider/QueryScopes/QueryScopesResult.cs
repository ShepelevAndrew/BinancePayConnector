namespace BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.QueryScopes;

public sealed record QueryScopesResult(
    string Status,
    string Code,
    DataObject? Data = null,
    string? ErrorMessage = null
);