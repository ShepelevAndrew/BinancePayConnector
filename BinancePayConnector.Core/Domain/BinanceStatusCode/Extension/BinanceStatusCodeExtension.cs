using System.ComponentModel;
using System.Net;
using BinancePayConnector.Core.Domain.BinanceStatusCode.Attributes;

namespace BinancePayConnector.Core.Domain.BinanceStatusCode.Extension;

public static class BinanceStatusCodeExtensions
{
    public static string ToCodeString(this BinanceStatusCode code)
        => code.GetAttribute<DescriptionAttribute>()?.Description ?? ((int)code).ToString("D6");

    public static HttpStatusCode ToHttpStatusCode(this BinanceStatusCode code)
        => (HttpStatusCode?)code.GetAttribute<HttpStatusAttribute>()?.Code ?? HttpStatusCode.InternalServerError;

    private static T? GetAttribute<T>(this Enum value) where T : Attribute
    {
        var field = value.GetType().GetField(value.ToString());
        return field?.GetCustomAttributes(typeof(T), false).FirstOrDefault() as T;
    }
}