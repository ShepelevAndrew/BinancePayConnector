namespace BinancePayConnector.Models.DirectDebit.CreateContract;

public sealed record ScenarioConfig(
    string ScenarioCode,
    decimal SingleUpperLimit,
    string Currency
);