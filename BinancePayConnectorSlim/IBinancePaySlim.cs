using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Clients.WebHookListener;
using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnectorSlim;

public interface IBinancePaySlim : IBinancePayReceiver
{
    Task<BinancePayResult<TResponse>> Send<TResponse>(
        IRequest<TResponse> request,
        CancellationToken ct = default);
}