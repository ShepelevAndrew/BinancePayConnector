using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.Reporting.DownloadBalanceReport;
using BinancePayConnector.Models.C2B.RestApi.Reporting.DownloadReport;
using BinancePayConnector.Models.C2B.RestApi.Reporting.QueryBalanceReport;
using BinancePayConnector.Services.Interfaces;

namespace BinancePayConnector.Services;

public class BinancePayReportingService(
    IBinancePayClient client
) : IBinancePayReportingService
{
    public async Task<BinancePayResult<IEnumerable<DownloadReportResult>>> DownloadReport(
        DownloadReport request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<IEnumerable<DownloadReportResult>, DownloadReport>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Reporting.DownloadReport,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<string?>> DownloadBalanceReport(
        DownloadBalanceReport request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<string?, DownloadBalanceReport>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Reporting.DownloadBalanceReport,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryBalanceReportResult>> QueryBalanceReport(
        QueryBalanceReport request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryBalanceReportResult, QueryBalanceReport>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Reporting.QueryBalanceReport,
            content: request,
            ct: ct);

        return response;
    }
}
