using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.CreateAuthorizationRequest;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.GetRequestRecord;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.QueryAuthenticationRecord;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.QueryScopes;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayTechnicalServiceProviderService
{
    Task<BinancePayResult<CreateAuthorizationResult>> CreateAuthorizationRequest(
        CreateAuthorizationRequest request,
        CancellationToken ct = default);

    Task<BinancePayResult<GetRequestRecordResult>> GetRequestRecord(
        GetRequestRecord request,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryScopesResult>> QueryScopes(
        CancellationToken ct = default);

    Task<BinancePayResult<QueryAuthenticationRecordResult>> QueryAuthenticationRecord(
        QueryAuthenticationRecord request,
        CancellationToken ct = default);
}
