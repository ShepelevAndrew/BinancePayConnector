using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.BatchPayout;
using BinancePayConnector.Core.Models.C2B.RestApi.Payout.PayoutQuery.ResultModel;
using BinancePayConnector.Models.Payout.ExecuteBatchPayout;
using BinancePayConnector.Models.Payout.ValidatePayoutReceiver;

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
