using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.TechnicalServiceProvider.GetRequestRecord;

namespace BinancePayConnector.MediatrStyle.Handlers.TechnicalServiceProvider;

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