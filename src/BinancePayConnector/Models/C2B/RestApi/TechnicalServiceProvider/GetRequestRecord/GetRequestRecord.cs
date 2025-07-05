using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.GetRequestRecord;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-technical-service-provider-get-record#request-parameters"/>.
/// </summary>
/// <param name="MerchantId"></param>
public sealed record GetRequestRecord(
    string MerchantId
) : IRequest<GetRequestRecordResult>;
