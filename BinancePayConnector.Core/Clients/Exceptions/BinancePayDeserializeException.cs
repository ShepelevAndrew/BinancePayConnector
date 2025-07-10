namespace BinancePayConnector.Core.Clients.Exceptions;

public class BinancePayDeserializeException : ArgumentNullException
{
    private new const string Message = "Serializer can't parse json to object.";

    public BinancePayDeserializeException(
        string json,
        Exception? innerException = null)
        : base(GetErrorMessage(json), innerException)
    {
    }

    public BinancePayDeserializeException(
        string json,
        string? paramName)
        : base(paramName, GetErrorMessage(json))
    {
    }

    private static string GetErrorMessage(string json) => Message + $" Json from response: {json}";
}
