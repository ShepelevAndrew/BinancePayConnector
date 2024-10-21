using System.Net;

namespace BinancePayConnector.Clients.Exceptions;

public class BinancePayRequestException : HttpRequestException
{
    public BinancePayRequestException(
        HttpStatusCode statusCode,
        string binanceStatusCode,
        string? message = default,
        Exception? inner = default)
        : base(message, inner, statusCode)
    {
        StatusCode = statusCode;
        BinanceStatusCode = binanceStatusCode;
    }

    public BinancePayRequestException(
        HttpStatusCode statusCode,
        string binanceStatusCode,
        HttpRequestError httpRequestError,
        string? message = default,
        Exception? inner = default)
        : base(httpRequestError, message, inner, statusCode)
    {
        StatusCode = statusCode;
        BinanceStatusCode = binanceStatusCode;
    }

    public new HttpStatusCode StatusCode { get; }

    public string BinanceStatusCode { get; }
}
