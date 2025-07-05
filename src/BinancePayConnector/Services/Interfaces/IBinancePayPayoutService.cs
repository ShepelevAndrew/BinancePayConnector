using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.RestApi.Payout.BatchPayout;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery.ResultModel;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutValidateReceiver;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayPayoutService
{
    Task<BinancePayResult<BatchPayoutResult>> BatchPayout(
        BatchPayout request,
        CancellationToken ct = default);

    Task<BinancePayResult<bool?>> PayoutValidateReceiver(
        PayoutValidateReceiver request,
        CancellationToken ct = default);

    Task<BinancePayResult<PayoutQueryResult>> PayoutQuery(
        PayoutQuery request,
        CancellationToken ct = default);
}
