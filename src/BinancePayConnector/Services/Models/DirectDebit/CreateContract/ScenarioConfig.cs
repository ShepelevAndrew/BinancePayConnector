namespace BinancePayConnector.Services.Models.DirectDebit;

public sealed record ScenarioConfig(
    string ScenarioCode,
    decimal SingleUpperLimit,
    string Currency
);