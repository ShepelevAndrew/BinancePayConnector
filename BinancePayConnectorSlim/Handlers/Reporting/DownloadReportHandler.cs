using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Reporting.DownloadReport;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Reporting;

public class DownloadReportHandler(
    IBinancePayClient client
) : IRequestHandler<DownloadReportRequest, IEnumerable<DownloadReportResult>>
{
    public async Task<BinancePayResult<IEnumerable<DownloadReportResult>>> ExecuteAsync(
        DownloadReportRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<IEnumerable<DownloadReportResult>, DownloadReportRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Reporting.DownloadReport,
            content: command,
            ct: ct);

        return response;
    }
}
