using BinancePayConnector.Models.C2B.RestApi.Reporting.DownloadReport.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.Reporting.DownloadReport;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-download-report#merchantdailyreportdata"/>.
/// </summary>
/// <param name="ReportType">Enum values from: <see cref="Enums.ReportType"/>.</param>
/// <param name="TransactionType">Enum values from: <see cref="Enums.TransactionType"/>.</param>
public sealed record DownloadReportResult(
    string ReportType,
    string TransactionType,
    string TransactionDate,
    string FileName,
    string DownloadUrl
);
