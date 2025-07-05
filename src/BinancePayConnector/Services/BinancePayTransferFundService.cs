using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.TransferFund.QueryTransfer;
using BinancePayConnector.Models.C2B.RestApi.TransferFund.TransferFund;
using BinancePayConnector.Services.Interfaces;

namespace BinancePayConnector.Services;

public class BinancePayTransferFundService(
    IBinancePayClient client
) : IBinancePayTransferFundService
{
    public async Task<BinancePayResult<TransferFundResult>> TransferFund(
        TransferFund request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<TransferFundResult, TransferFund>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TransferFund.TransferFundUri,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryTransferResult>> QueryTransferResult(
        QueryTransfer request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryTransferResult, QueryTransfer>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TransferFund.QueryTransferResult,
            content: request,
            ct: ct);

        return response;
    }
}
