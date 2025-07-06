using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.CreateAuthorizationRequest;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.GetRequestRecord;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.QueryAuthenticationRecord;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.QueryScopes;
using BinancePayConnector.Services.Interfaces;

namespace BinancePayConnector.Services;

public class BinancePayTechnicalServiceProviderService(
    IBinancePayClient client
) : IBinancePayTechnicalServiceProviderService
{
    public async Task<BinancePayResult<CreateAuthorizationResult>> CreateAuthorizationRequest(
        string merchantId,
        List<string> scopes,
        List<string> ipWhitelist,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<CreateAuthorizationResult, CreateAuthorizationRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TechnicalServiceProvider.CreateAuthorizeRequest,
            content: new CreateAuthorizationRequest(merchantId, scopes, ipWhitelist),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<GetRequestRecordResult>> GetRequestRecord(
        string merchantId,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<GetRequestRecordResult, GetRequestRecordRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TechnicalServiceProvider.GetRequestRecord,
            content: new GetRequestRecordRequest(merchantId),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryScopesResult>> GetScopes(
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryScopesResult>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TechnicalServiceProvider.QueryScoped,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryAuthenticationRecordResult>> GetAuthenticationRecord(
        int page,
        int rows,
        string? merchantId = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryAuthenticationRecordResult, QueryAuthenticationRecordRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TechnicalServiceProvider.QueryAuthenticationRecord,
            content: new QueryAuthenticationRecordRequest(page, rows, merchantId),
            ct: ct);

        return response;
    }
}
