using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.QueryAuthenticationRecord;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-technical-service-provider-query-record#request-parameters"/>.
/// </summary>
public sealed record QueryAuthenticationRecordRequest(
    int Page,
    int Rows,
    string? MerchantId = null
) : IRequest<QueryAuthenticationRecordResult>;
