using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.Common;

namespace BinancePayConnector.Clients.Extensions;

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
