using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Config.Endpoints;
using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.CreateContract;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.Payment;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.PaymentNotification;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.QueryContract;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.TerminateContract;
using BinancePayConnector.Services.Interfaces;
using BinancePayConnector.Models.DirectDebit.CreateContract;
using BinancePayConnector.Models.DirectDebit.ExecuteAuthorizedPayment;

namespace BinancePayConnector.Services;

public class BinancePayDirectDebitService(
    IBinancePayClient client
) : IBinancePayDirectDebitService
{
    public async Task<BinancePayResult<CreateContractResult>> CreateContract(
        MerchantContractIdentification identification,
        ScenarioConfig scenario,
        MerchantInfo merchant,
        PeriodicConfig? periodicSettings = null,
        long? requestExpireTime = null,
        long? contractEndTime = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<CreateContractResult, CreateContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.CreateContract,
            content: new CreateContractRequest(
                MerchantContractCode: identification.MerchantContractCode,
                ServiceName: identification.ServiceName,
                ScenarioCode: scenario.ScenarioCode,
                SingleUpperLimit: scenario.SingleUpperLimit,
                Currency: scenario.Currency,
                Periodic: periodicSettings?.Periodic ?? false,
                SubMerchantId: merchant.SubMerchantId,
                CycleDebitFixed: periodicSettings?.CycleDebitFixed,
                CycleType: periodicSettings?.CycleType,
                FirstDeductTime: periodicSettings?.FirstDeductTime,
                CycleValue: periodicSettings?.CycleValue,
                MerchantAccountNo: merchant.MerchantAccountNo,
                RequestExpireTime: requestExpireTime,
                ContractEndTime: contractEndTime),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryContractResult>> GetContractByContractId(
        long contractId,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryContractResult, QueryContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.QueryContract,
            content: new QueryContractRequest(ContractId: contractId),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<QueryContractResult>> GetContractByMerchantContractCode(
        string? merchantContractCode,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<QueryContractResult, QueryContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.QueryContract,
            content: new QueryContractRequest(MerchantContractCode: merchantContractCode),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<bool?>> TerminateContractByContractId(
        long contractId,
        string? terminationNotes = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<bool?, TerminateContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.TerminateContract,
            content: new TerminateContractRequest(ContractId: contractId, TerminationNotes: terminationNotes),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<bool?>> TerminateContractByMerchantContractCode(
        string merchantContractCode,
        string? terminationNotes = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<bool?, TerminateContractRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.TerminateContract,
            content: new TerminateContractRequest(MerchantContractCode: merchantContractCode, TerminationNotes: terminationNotes),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<PaymentNotificationResult>> NotifyPayment(
        string merchantRequestId,
        long bizId,
        decimal estimatedAmount,
        string? subMerchantId = null,
        string currency = Assets.Usdt,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<PaymentNotificationResult, PaymentNotificationRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.PaymentNotification,
            content: new PaymentNotificationRequest(merchantRequestId, bizId, estimatedAmount, subMerchantId, "DIRECT_DEBIT", currency),
            ct: ct);

        return response;
    }

    public async Task<BinancePayResult<PaymentResult>> ExecuteAuthorizedPayment(
        PaymentIdentification identification,
        PaymentOrder order,
        PaymentProduct product,
        PaymentOptionalMeta? meta = null,
        CancellationToken ct = default)
    {
        var response = await client.SendBinanceAsync<PaymentResult, PaymentRequest>(
            method: HttpMethod.Post,
            path: BinancePayEndpoints.DirectDebit.Payment,
            content: new PaymentRequest(
                MerchantRequestId: identification.MerchantRequestId,
                BizId: identification.BizId,
                Amount: order.Amount,
                ProductName: product.ProductName,
                TradeMode: order.TradeMode,
                Currency: order.Currency,
                SubMerchantId: meta?.SubMerchantId,
                PreBizId: meta?.PreBizId,
                ProductType: product.ProductType,
                ProductDetail: product.ProductDetail,
                WebhookUrl: meta?.WebhookUrl,
                OrderTags: meta?.OrderTags),
            ct: ct);

        return response;
    }
}
