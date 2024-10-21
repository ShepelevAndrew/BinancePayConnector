using BinancePayConnector.Clients.WebHookListener;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector;

public interface IBinancePaySlim : IBinancePayReceiver
{
    Task<BinancePayResult<TResponse>> Send<TResponse>(
        ICommand<TResponse> request,
        CancellationToken ct = default);
}