using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.Payout.BatchPayout;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery.ResultModel;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutValidateReceiver;
using BinancePayConnector.Services.Models.Payout.ExecuteBatchPayout;
using BinancePayConnector.Services.Models.Payout.ValidatePayoutReceiver;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayPayoutService
{
    Task<BinancePayResult<BatchPayoutResult>> ExecuteBatchPayout(
        PayoutIdentification identification,
        PayoutSummary summary,
        IEnumerable<TransferDetail> transferDetailList,
        string? bizScene = null,
        CancellationToken ct = default);

    Task<BinancePayResult<bool?>> ValidatePayoutReceiver(
        ReceiverIdentification identification,
        ReceiverRegistrationInfo? registrationInfo = null,
        CancellationToken ct = default);

    Task<BinancePayResult<PayoutQueryResult>> GetPayoutInfo(
        string requestId,
        IEnumerable<string>? detailStatus = null,
        CancellationToken ct = default);
}
