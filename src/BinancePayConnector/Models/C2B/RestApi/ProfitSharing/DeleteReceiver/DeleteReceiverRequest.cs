using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.ProfitSharing.DeleteReceiver;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-delete-receiver#request-parameters"/>.
/// </summary>
/// <param name="Account">Binance ID of receiver to be deleted.</param>
public sealed record DeleteReceiverRequest(
    string Account
) : IRequest<DeleteReceiverResult>;
