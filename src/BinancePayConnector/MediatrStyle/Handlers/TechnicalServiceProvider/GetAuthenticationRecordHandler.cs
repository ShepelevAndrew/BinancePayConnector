using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.QueryAuthenticationRecord;

namespace BinancePayConnector.MediatrStyle.Handlers.TechnicalServiceProvider;

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