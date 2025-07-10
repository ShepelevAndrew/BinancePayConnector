namespace BinancePayConnector.Core.Models.C2B.RestApi.TechnicalServiceProvider.QueryScopes;

public record DataObject(
    bool? AllowFeeShare = null,
    IEnumerable<string>? AllowScopes = null
);
