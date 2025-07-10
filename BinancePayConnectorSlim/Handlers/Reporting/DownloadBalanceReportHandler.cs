using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Reporting.DownloadBalanceReport;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.Reporting;

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
