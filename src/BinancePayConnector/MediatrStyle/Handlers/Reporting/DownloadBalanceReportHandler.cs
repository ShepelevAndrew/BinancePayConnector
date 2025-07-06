using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Reporting.DownloadBalanceReport;

namespace BinancePayConnector.MediatrStyle.Handlers.Reporting;

public class DownloadBalanceReportHandler(
    IBinancePayClient client
) : IRequestHandler<DownloadBalanceReportRequest, string?>
{
    public async Task<BinancePayResult<string?>> ExecuteAsync(
        DownloadBalanceReportRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<string?, DownloadBalanceReportRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Reporting.DownloadBalanceReport,
            content: command,
            ct: ct);

        return response;
    }
}
