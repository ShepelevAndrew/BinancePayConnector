using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.TechnicalServiceProvider.QueryAuthenticationRecord;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.TechnicalServiceProvider;

public class GetAuthenticationRecordHandler(
    IBinancePayClient client
) : IRequestHandler<QueryAuthenticationRecordRequest, QueryAuthenticationRecordResult>
{
    public async Task<BinancePayResult<QueryAuthenticationRecordResult>> ExecuteAsync(
        QueryAuthenticationRecordRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryAuthenticationRecordResult, QueryAuthenticationRecordRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TechnicalServiceProvider.QueryAuthenticationRecord,
            content: command,
            ct: ct);

        return response;
    }
}