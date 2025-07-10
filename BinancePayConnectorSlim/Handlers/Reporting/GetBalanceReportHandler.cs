using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Reporting.QueryBalanceReport;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Reporting;

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
