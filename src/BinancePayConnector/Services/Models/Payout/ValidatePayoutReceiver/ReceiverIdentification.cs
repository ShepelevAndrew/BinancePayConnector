using BinancePayConnector.Models.C2B.RestApi.Payout.Common.Enums;

namespace BinancePayConnector.Services.Models.Payout.ValidatePayoutReceiver;

public sealed record ReceiverIdentification(
    string ReceiverId,
    string ReceiveType = ReceiveType.BinanceId
);