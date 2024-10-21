namespace BinancePayConnector.Models.C2B.RestApi.DirectDebit.Payment;

/// <param name="IfProfitSharing">If specified and true, order will be tagged as profitsharing.</param>
public sealed record OrderTag(
    bool? IfProfitSharing = null);
