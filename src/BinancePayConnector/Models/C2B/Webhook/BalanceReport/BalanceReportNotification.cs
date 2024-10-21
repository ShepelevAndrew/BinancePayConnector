namespace BinancePayConnector.Models.C2B.Webhook.BalanceReport;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/webhook-balance-report#balancereportdata"/>.
/// </summary>
/// <param name="DownloadId">Download id, for any issue use this id to query.</param>
/// <param name="UserId">Spot user id.</param>
/// <param name="Status">2 = success.</param>
/// <param name="ExpirationTimestamp">Expiration timestamp of download link.</param>
/// <param name="CreateTime">Created time of the download document.</param>
public sealed record BalanceReportNotification(
    string DownloadType,
    long DownloadId,
    long UserId,
    string Status,
    string DownloadLink,
    long ExpirationTimestamp,
    string CreateTime
);
