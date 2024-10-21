namespace BinancePayConnector.Models.C2B.RestApi.Reporting.QueryBalanceReport;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-download-balance-report-query#response-parameters"/>.
/// </summary>
public record QueryBalanceReportResult(
    bool Exist,
    string Status,
    string? DownloadUrl = null
);
