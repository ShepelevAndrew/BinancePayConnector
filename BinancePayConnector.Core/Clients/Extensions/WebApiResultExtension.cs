using System.Net;
using BinancePayConnector.Core.Clients.Exceptions;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Domain.BinanceStatusCode;
using BinancePayConnector.Core.Domain.BinanceStatusCode.Extension;
using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.Common;

namespace BinancePayConnector.Core.Clients.Extensions;

public static class WebApiResultExtension
{
    public static BinancePayResult<TData> AsBinancePayResult<TData>(
        this WebApiResult<TData> result)
        => new(
            requestStatus: result.Status,
            binanceStatusCode: result.Code,
            body: result.Data,
            errorMessage: result.ErrorMessage
        );

    public static BinancePayResult<TData> AsBinancePayResult<TData>(
        this WebApiResult<object> result,
        HttpStatusCode statusCode)
        => new(
            statusCode: statusCode,
            requestStatus: result.Status,
            binanceStatusCode: result.Code,
            body: default,
            errorMessage: result.ErrorMessage
        );

    public static BinancePayResult<TData> AsBinancePayResult<TData>(
        this BinancePayRequestException e)
        => new(
            statusCode: e.StatusCode,
            requestStatus: RequestStatus.Fail,
            binanceStatusCode: e.BinanceStatusCode,
            body: default,
            errorMessage: e.Message
        );

    public static BinancePayResult<TData> AsBinancePayResult<TData>(
        this BinancePayDeserializeException e,
        HttpStatusCode statusCode)
        => new(
            statusCode: statusCode,
            requestStatus: RequestStatus.Fail,
            binanceStatusCode: BinanceStatusCode.RequestError.ToCodeString(),
            body: default,
            errorMessage: e.Message);
}
