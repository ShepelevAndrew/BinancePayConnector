using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.Reporting.DownloadReport;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-download-report#request-parameters"/>.
/// </summary>
/// <param name="ReportType">Enum values from: <see cref="Enums.ReportType"/>.</param>
/// <param name="StartDate">dd/MM/yyyy.</param>
/// <param name="EndDate">dd/MM/yyyy. From startDate to endDate can only support querying data within 3 months.</param>
/// <param name="TransactionType"> If the reportType is "Settlement",
/// this can be null If the reportType is "Transaction" field is required, either "Payment" or Payout".
/// Enum values from: <see cref="Enums.TransactionType"/>.
/// </param>
public record DownloadReport(
    string ReportType,
    string StartDate,
    string EndDate,
    string? TransactionType = null
) : ICommand<IEnumerable<DownloadReportResult>>;
