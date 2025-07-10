namespace BinancePayConnector.Core.Domain.BinanceStatusCode.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public sealed class HttpStatusAttribute(int code) : Attribute
{
    public int Code { get; } = code;
}