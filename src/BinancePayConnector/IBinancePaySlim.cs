using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Clients.WebHookListener;
using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector;

public interface IBinancePaySlim : IBinancePayReceiver
{
    Task<BinancePayResult<TResponse>> Send<TResponse>(
        IRequest<TResponse> request,
        CancellationToken ct = default);
}