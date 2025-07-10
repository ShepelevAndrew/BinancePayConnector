using BinancePayConnector.Core.Models.C2B.Common.Enums;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Common;

/// <param name="Status">
/// Status of the API request, enum value from <see cref="RequestStatus"/>.
/// </param>
/// <param name="Code">
/// Response result code, enum value from <see cref="Enums.BinanceStatusCodeConst"/>.
/// </param>
/// <param name="Data">Response body.</param>
/// <typeparam name="TData">Type of response body.</typeparam>
public record WebApiResult<TData>(
    string Status,
    string Code,
    TData? Data,
    string? ErrorMessage
);
