using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.TransferFund.TransferFund;

namespace BinancePayConnector.MediatrStyle.Handlers.TransferFund;

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
