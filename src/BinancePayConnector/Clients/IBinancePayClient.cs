using BinancePayConnector.Models.C2B.RestApi.Common;

namespace BinancePayConnector.Clients;

public interface IBinancePayClient
{
    string ApiBaseUri { get; }

    Task<WebApiResult<TResponse>> SendBinanceAsync<TResponse>(
        HttpMethod method,
        string path,
        CancellationToken ct = default);

    Task<WebApiResult<TResponse>> SendBinanceAsync<TResponse, TContent>(
        HttpMethod method,
        string path,
        TContent? content = default,
        CancellationToken ct = default);

    Task<TResponse> SendAsync<TResponse>(
        HttpMethod method,
        string path,
        CancellationToken ct = default);

    Task<TResponse> SendAsync<TResponse, TContent>(
        HttpMethod method,
        string path,
        TContent? content = default,
        CancellationToken ct = default);
}
