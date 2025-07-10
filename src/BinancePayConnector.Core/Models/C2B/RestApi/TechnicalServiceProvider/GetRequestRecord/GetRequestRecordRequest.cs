using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.TechnicalServiceProvider.GetRequestRecord;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-technical-service-provider-get-record#request-parameters"/>.
/// </summary>
/// <param name="MerchantId"></param>
public sealed record GetRequestRecordRequest(
    string MerchantId
) : IRequest<GetRequestRecordResult>;
