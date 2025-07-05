using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Payout.Common.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.Payout.PayoutValidateReceiver;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-payout-validate-receiver#request-parameters"/>.
/// </summary>
/// <param name="ReceiveType">Enum values from: <see cref="Common.Enums.ReceiveType"/>.</param>
/// <param name="ReceiverId">Receiver's BINANCE_ID depends on the receiver type.</param>
/// <param name="RegistrationEmail">Receiver's registration email address.</param>
/// <param name="RegistrationMobileNumber">Receiver's mobile number.</param>
/// <param name="RegistrationMobileCode">Receiver's mobile code eg:971 for UAE.</param>
public sealed record PayoutValidateReceiver(
    string ReceiverId,
    string ReceiveType = ReceiveType.BinanceId,
    string? RegistrationEmail = null,
    string? RegistrationMobileNumber = null,
    string? RegistrationMobileCode = null
) : IRequest<bool?>;
