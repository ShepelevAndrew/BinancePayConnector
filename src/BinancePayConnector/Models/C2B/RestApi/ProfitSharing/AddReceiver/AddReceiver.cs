using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.ProfitSharing.AddReceiver;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-add-receiver#request-parameters"/>.
/// </summary>
/// <param name="Account">Binance id of Receiver.</param>
public sealed record AddReceiver(
    string Account
) : ICommand<AddReceiverResult>;
