namespace BinancePayConnector.Config.Endpoints;

public static partial class BinancePayEndpoints
{
    public static class TechnicalServiceProvider
    {
        public const string CreateAuthorizeRequest = CommonUri + "/service/provider/create";
        public const string GetRequestRecord = CommonUri + "/service/provider/record/get";
        public const string QueryScoped = CommonUri + "/service/provider/config/query";
        public const string QueryAuthenticationRecord = CommonUri + "/service/provider/record";
    }
}
