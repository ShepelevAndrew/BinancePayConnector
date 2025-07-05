using BinancePayConnector.Clients.Models.Result;

namespace BinancePayConnector.MediatrStyle.Abstractions;

public interface IRequestHandler<in TCommand, TResponse>
    where TCommand : IRequest<TResponse>
{
    public Task<BinancePayResult<TResponse>> ExecuteAsync(
        TCommand command,
        CancellationToken ct = default);
}
