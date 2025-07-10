namespace BinancePayConnector.Core.Models.C2B.RestApi.TechnicalServiceProvider.QueryAuthenticationRecord;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-technical-service-provider-query-record#dataobject"/>.
/// </summary>
public sealed record QueryAuthenticationRecordResult(
    long Total,
    List<RecordObject> Rows
);
