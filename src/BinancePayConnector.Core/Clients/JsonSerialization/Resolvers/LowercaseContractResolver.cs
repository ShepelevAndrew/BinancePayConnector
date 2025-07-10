using System.Globalization;
using Newtonsoft.Json.Serialization;

namespace BinancePayConnector.Core.Clients.JsonSerialization.Resolvers;

public class LowercaseContractResolver : DefaultContractResolver
{
    protected override string ResolvePropertyName(string propertyName)
    {         
        if (!string.IsNullOrEmpty(propertyName) && propertyName.Length > 1)
        {
            return char.ToLower(propertyName[0], CultureInfo.InvariantCulture) + propertyName[1..];
        }

        return propertyName.ToLowerInvariant(); // In case the property name is a single letter
    }
}
