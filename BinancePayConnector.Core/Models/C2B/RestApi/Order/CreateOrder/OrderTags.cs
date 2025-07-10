namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder;

/// <param name="IfProfitSharing">If specified and true, order will be tagged as profit sharing.</param>
public sealed record OrderTags(
    bool? IfProfitSharing = null
);
