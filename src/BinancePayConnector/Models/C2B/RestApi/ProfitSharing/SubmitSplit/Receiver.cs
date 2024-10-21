namespace BinancePayConnector.Models.C2B.RestApi.ProfitSharing.SubmitSplit;

/// <param name="Account">Binance ID of receiver. Receiver must have been registered with add-receiver API.</param>
public sealed record Receiver(
    string Account,
    decimal Amount,
    string Description,
    string? WebhookUrl = null
);
