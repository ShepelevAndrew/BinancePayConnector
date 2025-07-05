using BinancePayConnector.Clients.Models.Result;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.CreateContract;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.Payment;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.PaymentNotification;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.QueryContract;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayDirectDebitService
{
    Task<BinancePayResult<CreateContractResult>> CreateContract(
        CreateContractRequest request,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryContractResult>> QueryContractByContractId(
        long contractId,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryContractResult>> QueryContractByMerchantContractCode(
        string merchantContractCode,
        CancellationToken ct = default);

    Task<BinancePayResult<bool?>> TerminateContractByContractId(
        long contractId,
        string? terminationNotes = null,
        CancellationToken ct = default);

    Task<BinancePayResult<bool?>> TerminateContractByMerchantContractCode(
        string merchantContractCode,
        string? terminationNotes = null,
        CancellationToken ct = default);


    Task<BinancePayResult<PaymentNotificationResult>> PaymentNotify(
        string merchantRequestId,
        long bizId,
        decimal estimatedAmount,
        string? subMerchantId = null,
        string currency = Assets.Usdt,
        CancellationToken ct = default);

    Task<BinancePayResult<PaymentResult>> AuthorizationPay(
        PaymentRequest request,
        CancellationToken ct = default);
}
