using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.TransferFund.QueryTransfer;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.TransferFund;

public class GetTransferResultHandler(
    IBinancePayClient client
) : IRequestHandler<QueryTransferRequest, QueryTransferResult>
{
    public async Task<BinancePayResult<QueryTransferResult>> ExecuteAsync(
        QueryTransferRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryTransferResult, QueryTransferRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TransferFund.QueryTransferResult,
            content: command,
            ct: ct);

        return response;
    }
}
