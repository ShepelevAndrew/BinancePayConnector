using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.CreateAuthorizationRequest;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.GetRequestRecord;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.QueryAuthenticationRecord;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.QueryScopes;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Services.Models.Result;
using BinancePayConnector.Services.Extensions;

namespace BinancePayConnector.Services;

public class BinancePayTechnicalServiceProviderService(
    IBinancePayClient client)
        : IBinancePayTechnicalServiceProviderService
{
    public async Task<BinancePayResult<CreateAuthorizationResult>> CreateAuthorizationRequest(
        CreateAuthorizationRequest request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<CreateAuthorizationResult, CreateAuthorizationRequest>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.TechnicalServiceProvider.CreateAuthorizeRequest,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<CreateAuthorizationResult>();
        }
    }

    public async Task<BinancePayResult<GetRequestRecordResult>> GetRequestRecord(
        GetRequestRecord request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<GetRequestRecordResult, GetRequestRecord>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.TechnicalServiceProvider.GetRequestRecord,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<GetRequestRecordResult>();
        }
    }

    public async Task<BinancePayResult<QueryScopesResult>> QueryScopes(
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<QueryScopesResult>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.TechnicalServiceProvider.QueryScoped,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<QueryScopesResult>();
        }
    }

    public async Task<BinancePayResult<QueryAuthenticationRecordResult>> QueryAuthenticationRecord(
        QueryAuthenticationRecord request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<QueryAuthenticationRecordResult, QueryAuthenticationRecord>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.TechnicalServiceProvider.QueryAuthenticationRecord,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<QueryAuthenticationRecordResult>();
        }
    }
}
