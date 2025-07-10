using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.TechnicalServiceProvider.CreateAuthorizationRequest;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.TechnicalServiceProvider;

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