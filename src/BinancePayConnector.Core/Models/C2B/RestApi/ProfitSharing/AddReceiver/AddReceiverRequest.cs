using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.AddReceiver;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-add-receiver#request-parameters"/>.
/// </summary>
/// <param name="Account">Binance id of Receiver.</param>
public sealed record AddReceiverRequest(
    string Account
) : IRequest<AddReceiverResult>;
