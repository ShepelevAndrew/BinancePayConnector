using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector.MediatrStyle.Abstractions;

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    public Task<BinancePayResult<TResponse>> ExecuteAsync(
        TCommand command,
        CancellationToken ct = default);
}
