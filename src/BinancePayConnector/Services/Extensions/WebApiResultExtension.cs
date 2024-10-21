using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Common;
using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector.Services.Extensions;

public static class WebApiResultExtension
{
    public static BinancePayResult<TData> AsBinancePayResult<TData>(
        this WebApiResult<TData> result)
        => new(
            result.Status,
            result.Code,
            result.Data,
            result.ErrorMessage
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
}
