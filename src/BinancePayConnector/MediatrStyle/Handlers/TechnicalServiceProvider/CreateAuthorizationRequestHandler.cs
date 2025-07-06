using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.CreateAuthorizationRequest;

namespace BinancePayConnector.MediatrStyle.Handlers.TechnicalServiceProvider;

public class CreateAuthorizationRequestHandler(
    IBinancePayClient client
) : IRequestHandler<CreateAuthorizationRequest, CreateAuthorizationResult>
{
    public async Task<BinancePayResult<CreateAuthorizationResult>> ExecuteAsync(
        CreateAuthorizationRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<CreateAuthorizationResult, CreateAuthorizationRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TechnicalServiceProvider.CreateAuthorizeRequest,
            content: command,
            ct: ct);

        return response;
    }
}