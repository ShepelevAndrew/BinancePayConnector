namespace BinancePayConnector.Services.Models.Payout.ValidatePayoutReceiver;

public sealed record ReceiverRegistrationInfo(
    string? RegistrationEmail = null,
    string? RegistrationMobileNumber = null,
    string? RegistrationMobileCode = null
);