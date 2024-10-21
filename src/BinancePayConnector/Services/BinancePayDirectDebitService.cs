using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Exceptions;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.CreateContract;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.Payment;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.PaymentNotification;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.QueryContract;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.TerminateContract;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Services.Models.Result;
using BinancePayConnector.Services.Extensions;

namespace BinancePayConnector.Services;

public class BinancePayDirectDebitService(
    IBinancePayClient client
) : IBinancePayDirectDebitService
{
    public async Task<BinancePayResult<CreateContractResult>> CreateContract(
        CreateContract request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<CreateContractResult, CreateContract>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.DirectDebit.CreateContract,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<CreateContractResult>();
        }
    }

    public async Task<BinancePayResult<QueryContractResult>> QueryContract(
        QueryContract request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<QueryContractResult, QueryContract>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.DirectDebit.QueryContract,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<QueryContractResult>();
        }
    }

    public async Task<BinancePayResult<bool?>> TerminateContract(
        TerminateContract request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<bool?, TerminateContract>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.DirectDebit.TerminateContract,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<bool?>();
        }
    }

    public async Task<BinancePayResult<PaymentNotificationResult>> PaymentNotify(
        PaymentNotification request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<PaymentNotificationResult, PaymentNotification>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.DirectDebit.PaymentNotification,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<PaymentNotificationResult>();
        }
    }

    public async Task<BinancePayResult<PaymentResult>> AuthorizationPay(
        Payment request,
        CancellationToken ct = default)
    {
        try
        {
            var response = await client.SendBinanceAsync<PaymentResult, Payment>(
                method: HttpMethod.Post,
                path: BinancePayEndpoints.DirectDebit.Payment,
                content: request,
                ct: ct);

            return response.AsBinancePayResult();
        }
        catch (BinancePayRequestException e)
        {
            return e.AsBinancePayResult<PaymentResult>();
        }
    }
}
