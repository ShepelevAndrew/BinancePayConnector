using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Reporting.DownloadBalanceReport;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-download-balance-report#request-parameters"/>.
/// </summary>
/// <param name="ReportType">Valid value is "Balance".</param>
/// <param name="StartDate">Enum values from: <see cref="Common.Enums.WalletType"/>.</param>
/// <param name="EndDate">YYYY-MM-DD.</param>
/// <param name="WalletType">YYYY-MM-DD. End date must be before yesterday..</param>
public record DownloadBalanceReportRequest(
    string StartDate,
    string EndDate,
    string ReportType = "Balance",
    string? WalletType = null
) : IRequest<string?>;
