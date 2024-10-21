using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.Payout.BatchPayout;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutQuery.ResultModel;
using BinancePayConnector.Models.C2B.RestApi.Payout.PayoutValidateReceiver;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Services.Models.Result;
using BinancePayConnector.Services.Extensions;

namespace BinancePayConnector.Services;

public class BinancePayPayoutService(
    IBinancePayClient client)
        : IBinancePayPayoutService
{
    public async Task<BinancePayResult<BatchPayoutResult>> BatchPay(
        BatchPayout request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<BatchPayoutResult, BatchPayout>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Payout.BatchPayout,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<BatchPayoutResult>();
        }
    }

    public async Task<BinancePayResult<bool?>> PayoutValidateReceiver(
        PayoutValidateReceiver request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<bool?, PayoutValidateReceiver>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Payout.ValidateReceiver,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<bool?>();
        }
    }

    public async Task<BinancePayResult<PayoutQueryResult>> PayoutQuery(
        PayoutQuery request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<PayoutQueryResult, PayoutQuery>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.Payout.PayoutQuery,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<PayoutQueryResult>();
        }
    }
}
