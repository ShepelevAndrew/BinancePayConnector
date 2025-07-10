namespace BinancePayConnector.Core.Config.Endpoints;

public static partial class BinancePayEndpoints
{
    public static class ProfitSharing
    {
        public const string AddReceiver = CommonUri + "/profitsharing/v1/add-receiver";
        public const string QueryReceiver = CommonUri + "/profitsharing/v1/query-receiver";
        public const string DeleteReceiver = CommonUri + "/profitsharing/v1/del-receiver";
        public const string SubmitSplit = CommonUri + "/profitsharing/v1/submit-split";
        public const string QuerySplit = CommonUri + "/profitsharing/v1/query-split";
        public const string SplitReturn = CommonUri + "/profitsharing/v1/return";
    }
}
