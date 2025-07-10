namespace BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.AddReceiver;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-add-receiver#response"/>.
/// </summary>
/// <param name="Account">Account from the request body.</param>
public sealed record AddReceiverResult(
    string Account
);
