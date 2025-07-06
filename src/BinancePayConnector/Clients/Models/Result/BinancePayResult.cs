using System.Net;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Common;
using BinancePayConnector.Models.C2B.RestApi.Common.Enums;

namespace BinancePayConnector.Clients.Models.Result;

/// <summary>
/// Wrapper over base Binance Pay API response (<see cref="WebApiResult{TData}"/>).
/// </summary>
/// <typeparam name="TBody">Type of response body, same for <see cref="WebApiResult{TData}"/>.</typeparam>
public class BinancePayResult<TBody>
{
    private readonly string _requestStatus;

    /// <param name="requestStatus">Enum value from <see cref="RequestStatus"/>.</param>
    /// <param name="binanceStatusCode">Enum value from <see cref="BinanceStatusCodeConst"/>.</param>
    /// <param name="body">Response body.</param>
    /// <param name="errorMessage">Error message of response.</param>
    public BinancePayResult(
        string requestStatus,
        string binanceStatusCode,
        TBody? body,
        string? errorMessage = null)
    {
        _requestStatus = requestStatus;
        StatusCode = ConvertBinanceStatusCodeToWeb(binanceStatusCode);
        BinanceStatusCode = ConvertStringBinanceStatusCodeToEnum(binanceStatusCode);
        Body = body;
        ErrorMessage = errorMessage;
    }

    /// <param name="statusCode">Http status code of response, usually use if request was failed.</param>
    /// <param name="requestStatus">Enum value from <see cref="RequestStatus"/>.</param>
    /// <param name="binanceStatusCode">Enum value from <see cref="BinanceStatusCodeConst"/>.</param>
    /// <param name="body">Response body.</param>
    /// <param name="errorMessage">Error message of response.</param>
    public BinancePayResult(
        HttpStatusCode statusCode,
        string requestStatus,
        string binanceStatusCode,
        TBody? body,
        string? errorMessage = null)
        : this(requestStatus, binanceStatusCode, body, errorMessage)
        => StatusCode = statusCode;

    /// <summary>
    /// If request was failed, then StatusCode is originally HttpStatusCode of http response,
    /// otherwise StatusCode is converted BinanceStatusCode to Http as <see cref="BinanceStatusCodeConst"/>.<see cref="BinanceStatusCodeConst.MapToWeb"/>.
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// It's binance status code, but if BinanceStatusCode is <see cref="BinanceStatusCode.RequestError"/>
    /// it means your request to Binance Pay Api is failed, please check StatusCode of this object to check originally returned http status code.
    /// </summary>
    public BinanceStatusCode BinanceStatusCode { get; }

    /// <summary>
    /// Response body from Binance Pay Api, based on your request.
    /// </summary>
    public TBody? Body { get; }

    /// <summary>
    /// Error message of response.
    /// </summary>
    public string? ErrorMessage { get; }

    public bool IsSuccess => _requestStatus == RequestStatus.Success;

    public bool IsFailure => _requestStatus == RequestStatus.Fail;

    private static HttpStatusCode ConvertBinanceStatusCodeToWeb(string statusCode)
        => (HttpStatusCode)BinanceStatusCodeConst.MapToWeb
            .GetValueOrDefault(statusCode, (int)HttpStatusCode.InternalServerError);

    private static BinanceStatusCode ConvertStringBinanceStatusCodeToEnum(string text)
        => int.TryParse(text, out var value)
            ? (BinanceStatusCode)value
            : BinanceStatusCode.UnknownError;
}
