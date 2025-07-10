using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.TransferFund.QueryTransfer;
using BinancePayConnector.Core.Models.C2B.RestApi.TransferFund.TransferFund;
using BinancePayConnector.Services.Interfaces;

namespace BinancePayConnector.Services;

public class BinancePayTransferFundService(
    IBinancePayClient client
) : IBinancePayTransferFundService
{
    public async Task<BinancePayResult<TransferFundResult>> FundTransfer(
        string requestId,
        string currency,
        string amount,
        string transferType,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<TransferFundResult, TransferFundRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TransferFund.TransferFundUri,
            content: new TransferFundRequest(requestId, currency, amount, transferType),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryTransferResult>> GetTransferResult(
        string tranId,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryTransferResult, QueryTransferRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.TransferFund.QueryTransferResult,
            content: new QueryTransferRequest(tranId),
            ct: ct);

        return response;
    }
}
