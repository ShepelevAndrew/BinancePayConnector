namespace BinancePayConnector.Config.Endpoints;

public static partial class BinancePayEndpoints
{
    public static class Convert
    {
        public const string ListAllConvertPairs = CommonUri + "/otc-portal/get-to-selector";
        public const string SendQuote = CommonUri + "/otc-portal/get-quote";
        public const string ExecuteQuote = CommonUri + "/otc-portal/execute-quote";
        public const string QueryQuote = CommonUri + "/otc-portal/query-trade-order";
    }
}
