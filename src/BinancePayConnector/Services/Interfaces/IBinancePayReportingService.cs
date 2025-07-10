using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Models.C2B.RestApi.Reporting.DownloadReport;
using BinancePayConnector.Core.Models.C2B.RestApi.Reporting.QueryBalanceReport;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayReportingService
{
    Task<BinancePayResult<IEnumerable<DownloadReportResult>>> DownloadReport(
        string reportType,
        string startDate,
        string endDate,
        string? transactionType = null,
        CancellationToken ct = default);

    Task<BinancePayResult<string?>> DownloadBalanceReport(
        string startDate,
        string endDate,
        string reportType = "Balance",
        string? walletType = null,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryBalanceReportResult>> GetBalanceReport(
        string downloadId,
        CancellationToken ct = default);
}
