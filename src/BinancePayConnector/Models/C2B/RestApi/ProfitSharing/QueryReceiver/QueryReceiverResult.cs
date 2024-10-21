namespace BinancePayConnector.Models.C2B.RestApi.ProfitSharing.QueryReceiver;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-query-receiver#response"/>.
/// </summary>
public sealed record QueryReceiverResult(
    List<string> AccountList,
    int TotalPageNum,
    long TotalRecordNum,
    int CurrentPageNum,
    int CurrentPageSize
);
