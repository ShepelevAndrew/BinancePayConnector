using System.Net;

namespace BinancePayConnector.Clients.Exceptions;

public class BinancePayRequestException(
    HttpStatusCode statusCode,
    string binanceStatusCode,
    string? message = null,
    Exception? inner = null
) : HttpRequestException(message, inner, statusCode)
{
    public new HttpStatusCode StatusCode { get; } = statusCode;

    public string BinanceStatusCode { get; } = binanceStatusCode;
}
