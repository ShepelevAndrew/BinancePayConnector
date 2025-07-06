using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.CreateAuthorizationRequest;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.GetRequestRecord;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.QueryAuthenticationRecord;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.QueryScopes;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayTechnicalServiceProviderService
{
    Task<BinancePayResult<CreateAuthorizationResult>> CreateAuthorizationRequest(
        string merchantId,
        List<string> scopes,
        List<string> ipWhitelist,
        CancellationToken ct = default);

    Task<BinancePayResult<GetRequestRecordResult>> GetRequestRecord(
        string merchantId,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryScopesResult>> GetScopes(
        CancellationToken ct = default);

    Task<BinancePayResult<QueryAuthenticationRecordResult>> GetAuthenticationRecord(
        int page,
        int rows,
        string? merchantId = null,
        CancellationToken ct = default);
}
