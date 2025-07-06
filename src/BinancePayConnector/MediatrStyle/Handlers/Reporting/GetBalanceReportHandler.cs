using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Reporting.QueryBalanceReport;

namespace BinancePayConnector.MediatrStyle.Handlers.Reporting;

public class GetBalanceReportHandler(
    IBinancePayClient client
) : IRequestHandler<QueryBalanceReportRequest, QueryBalanceReportResult>
{
    public async Task<BinancePayResult<QueryBalanceReportResult>> ExecuteAsync(
        QueryBalanceReportRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryBalanceReportResult, QueryBalanceReportRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Reporting.QueryBalanceReport,
            content: command,
            ct: ct);

        return response;
    }
}
