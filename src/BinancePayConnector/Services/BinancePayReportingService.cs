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
        string reportType,
        string startDate,
        string endDate,
        string? transactionType = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<IEnumerable<DownloadReportResult>, DownloadReportRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Reporting.DownloadReport,
            content: new DownloadReportRequest(reportType, startDate, endDate, transactionType),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<string?>> DownloadBalanceReport(
        string startDate,
        string endDate,
        string reportType = "Balance",
        string? walletType = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<string?, DownloadBalanceReportRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Reporting.DownloadBalanceReport,
            content: new DownloadBalanceReportRequest(startDate, endDate, reportType, walletType),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryBalanceReportResult>> GetBalanceReport(
        string downloadId,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryBalanceReportResult, QueryBalanceReportRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Reporting.QueryBalanceReport,
            content: new QueryBalanceReportRequest(downloadId),
            ct: ct);

        return response;
    }
}
