using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Reporting.DownloadReport;

namespace BinancePayConnector.MediatrStyle.Handlers.Reporting;

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
