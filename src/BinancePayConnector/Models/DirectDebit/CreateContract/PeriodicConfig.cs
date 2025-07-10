namespace BinancePayConnector.Models.DirectDebit.CreateContract;

public sealed record PeriodicConfig(
    bool Periodic,
    bool? CycleDebitFixed = null,
    string? CycleType = null,
    int? CycleValue = null,
    long? FirstDeductTime = null
);