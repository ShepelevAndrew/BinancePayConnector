using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.TransferFund.QueryTransfer;

namespace BinancePayConnector.MediatrStyle.Handlers.TransferFund;

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
