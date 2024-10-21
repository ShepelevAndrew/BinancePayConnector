namespace BinancePayConnector.Config.Endpoints;

public static partial class BinancePayEndpoints
{
    public static class Reporting
    {
        public const string DownloadReport = CommonUri + "/report/get-file";
        public const string DownloadBalanceReport = CommonUri + "/balance-report";
        public const string QueryBalanceReport = CommonUri + "/balance-report/query";
    }
}
