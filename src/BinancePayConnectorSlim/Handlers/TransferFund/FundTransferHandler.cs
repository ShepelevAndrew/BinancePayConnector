using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.TransferFund.TransferFund;
using BinancePayConnectorSlim.Abstractions;

namespace BinancePayConnectorSlim.Handlers.TransferFund;

public class FundTransferHandler(
    IBinancePayClient client
) : IRequestHandler<TransferFundRequest, TransferFundResult>
{
    public async Task<BinancePayResult<TransferFundResult>> ExecuteAsync(
        TransferFundRequest command,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<TransferFundResult, TransferFundRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TransferFund.TransferFundUri,
            content: command,
            ct: ct);

        return response;
    }
}
