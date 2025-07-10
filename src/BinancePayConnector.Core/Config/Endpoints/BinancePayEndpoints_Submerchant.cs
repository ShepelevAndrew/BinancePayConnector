namespace BinancePayConnector.Core.Config.Endpoints;

public static partial class BinancePayEndpoints
{
    public static class SubMerchant
    {
        public const string CreateSubMerchant = CommonUri + "/submerchant/add";
        public const string ModifySubMerchant = CommonUri + "/submerchant/modify";
    }
}
