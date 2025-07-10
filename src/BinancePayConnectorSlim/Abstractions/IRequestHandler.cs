using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnectorSlim.Abstractions;

public interface IRequestHandler<in TCommand, TResponse>
    where TCommand : IRequest<TResponse>
{
    public Task<BinancePayResult<TResponse>> ExecuteAsync(
        TCommand command,
        CancellationToken ct = default);
}
