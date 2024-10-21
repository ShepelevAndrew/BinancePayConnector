namespace BinancePayConnector.Models.C2B.RestApi.ProfitSharing.DeleteReceiver;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-delete-receiver#response"/>.
/// </summary>
/// <param name="Account">Account from the request body.</param>
public sealed record DeleteReceiverResult(
    string Account
);
