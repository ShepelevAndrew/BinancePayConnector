using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.Reporting.DownloadBalanceReport;
using BinancePayConnector.Models.C2B.RestApi.Reporting.DownloadReport;
using BinancePayConnector.Models.C2B.RestApi.Reporting.QueryBalanceReport;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayReportingService
{
    Task<BinancePayResult<IEnumerable<DownloadReportResult>>> DownloadReport(
        DownloadReport request,
        CancellationToken ct = default);

    Task<BinancePayResult<string?>> DownloadBalanceReport(
        DownloadBalanceReport request,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryBalanceReportResult>> QueryBalanceReport(
        QueryBalanceReport request,
        CancellationToken ct = default);
}
