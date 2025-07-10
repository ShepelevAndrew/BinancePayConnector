using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.BatchPayout;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutQuery;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutQuery.ResultModel;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutValidateReceiver;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Models.Payout.ExecuteBatchPayout;
using BinancePayConnector.Models.Payout.ValidatePayoutReceiver;

namespace BinancePayConnector.Services;

public class BinancePayPayoutService(
    IBinancePayClient client
) : IBinancePayPayoutService
{
    public async Task<BinancePayResult<BatchPayoutResult>> ExecuteBatchPayout(
        PayoutIdentification identification,
        PayoutSummary summary,
        IEnumerable<TransferDetail> transferDetailList,
        string? bizScene = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<BatchPayoutResult, BatchPayoutRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Payout.BatchPayout,
            content: new BatchPayoutRequest(
                RequestId: identification.RequestId,
                BatchName: identification.BatchName,
                Currency: summary.Currency,
                TotalAmount: summary.TotalAmount,
                TotalNumber: summary.TotalNumber,
                TransferDetailList: transferDetailList,
                BizScene: bizScene),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<bool?>> ValidatePayoutReceiver(
        ReceiverIdentification identification,
        ReceiverRegistrationInfo? registrationInfo = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<bool?, PayoutValidateReceiverRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Payout.ValidateReceiver,
            content: new PayoutValidateReceiverRequest(
                ReceiverId: identification.ReceiverId,
                ReceiveType: identification.ReceiveType,
                RegistrationEmail: registrationInfo?.RegistrationEmail,
                RegistrationMobileNumber: registrationInfo?.RegistrationMobileNumber,
                RegistrationMobileCode: registrationInfo?.RegistrationMobileCode),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<PayoutQueryResult>> GetPayoutInfo(
        string requestId,
        IEnumerable<string>? detailStatus = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<PayoutQueryResult, PayoutQueryRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.Payout.PayoutQuery,
            content: new PayoutQueryRequest(requestId, detailStatus),
            ct: ct);

        return response;
    }
}
