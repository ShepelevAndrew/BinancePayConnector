using BinancePayConnector.Clients;
using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Config.Endpoints;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.CreateContract;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.Payment;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.PaymentNotification;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.QueryContract;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.TerminateContract;
using BinancePayConnector.Services.Interfaces;

namespace BinancePayConnector.Services;

public class BinancePayDirectDebitService(
    IBinancePayClient client
) : IBinancePayDirectDebitService
{
    public async Task<BinancePayResult<CreateContractResult>> CreateContract(
        CreateContractRequest request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<CreateContractResult, CreateContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.CreateContract,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryContractResult>> QueryContractByContractId(
        long contractId,
        CancellationToken ct = default)
    {
        var request = new QueryContractRequest(ContractId: contractId);
        var response = await client.SendBinanceAsync<QueryContractResult, QueryContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.QueryContract,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryContractResult>> QueryContractByMerchantContractCode(
        string? merchantContractCode,
        CancellationToken ct = default)
    {
        var request = new QueryContractRequest(MerchantContractCode: merchantContractCode);
        var response = await client.SendBinanceAsync<QueryContractResult, QueryContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.QueryContract,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<bool?>> TerminateContractByContractId(
        long contractId,
        string? terminationNotes = null,
        CancellationToken ct = default)
    {
        var request = new TerminateContractRequest(ContractId: contractId, TerminationNotes: terminationNotes);
        var response = await client.SendBinanceAsync<bool?, TerminateContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.TerminateContract,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<bool?>> TerminateContractByMerchantContractCode(
        string merchantContractCode,
        string? terminationNotes = null,
        CancellationToken ct = default)
    {
        var request = new TerminateContractRequest(MerchantContractCode: merchantContractCode, TerminationNotes: terminationNotes);
        var response = await client.SendBinanceAsync<bool?, TerminateContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.TerminateContract,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<PaymentNotificationResult>> PaymentNotify(
        string merchantRequestId,
        long bizId,
        decimal estimatedAmount,
        string? subMerchantId = null,
        string currency = Assets.Usdt,
        CancellationToken ct = default)
    {
        var request = new PaymentNotificationRequest(merchantRequestId, bizId, estimatedAmount, subMerchantId, "DIRECT_DEBIT", currency);
        var response = await client.SendBinanceAsync<PaymentNotificationResult, PaymentNotificationRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.PaymentNotification,
            content: request,
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<PaymentResult>> AuthorizationPay(
        PaymentRequest request,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<PaymentResult, PaymentRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.Payment,
            content: request,
            ct: ct);

        return response;
    }
}
