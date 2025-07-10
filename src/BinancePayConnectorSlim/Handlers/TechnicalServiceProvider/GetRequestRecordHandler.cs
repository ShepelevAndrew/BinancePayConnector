using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.TechnicalServiceProvider.GetRequestRecord;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.TechnicalServiceProvider;

public class GetRequestRecordHandler(
    IBinancePayClient client
) : IRequestHandler<GetRequestRecordRequest, GetRequestRecordResult>
{
    public async Task<BinancePayResult<GetRequestRecordResult>> ExecuteAsync(
        GetRequestRecordRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<GetRequestRecordResult, GetRequestRecordRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TechnicalServiceProvider.GetRequestRecord,
            content: command,
            ct: ct);

        return response;
    }
}