namespace BinancePayConnector.Models.C2B.RestApi.Reporting.QueryBalanceReport;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-download-balance-report-query#request-parameters"/>.
/// </summary>
/// <param name="DownloadId">The data returned at download balance report API.</param>
public record QueryBalanceReport(
    string DownloadId
);
