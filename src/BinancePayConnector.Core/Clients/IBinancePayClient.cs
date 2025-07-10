using BinancePayConnector.Core.Clients.Models;

namespace BinancePayConnector.Core.Clients;

public interface IBinancePayClient
{
    string ApiBaseUri { get; }

    Task<BinancePayResult<TResponse>> SendBinanceAsync<TResponse>(
        HttpMethod method,
        string path,
        CancellationToken ct = default);

    Task<BinancePayResult<TResponse>> SendBinanceAsync<TResponse, TContent>(
        HttpMethod method,
        string path,
        TContent? content = default,
        CancellationToken ct = default);
}
