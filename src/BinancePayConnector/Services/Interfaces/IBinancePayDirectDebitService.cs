using BinancePayConnector.Core.Clients.Models;
using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.CreateContract;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.Payment;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.PaymentNotification;
using BinancePayConnector.Core.Models.C2B.RestApi.DirectDebit.QueryContract;
using BinancePayConnector.Models.DirectDebit.CreateContract;
using BinancePayConnector.Models.DirectDebit.ExecuteAuthorizedPayment;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayDirectDebitService
{
    Task<BinancePayResult<CreateContractResult>> CreateContract(
        MerchantContractIdentification identification,
        ScenarioConfig scenario,
        MerchantInfo merchant,
        PeriodicConfig? periodicSettings = null,
        long? requestExpireTime = null,
        long? contractEndTime = null,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryContractResult>> GetContractByContractId(
        long contractId,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryContractResult>> GetContractByMerchantContractCode(
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


    Task<BinancePayResult<PaymentNotificationResult>> NotifyPayment(
        string merchantRequestId,
        long bizId,
        decimal estimatedAmount,
        string? subMerchantId = null,
        string currency = Assets.Usdt,
        CancellationToken ct = default);

    Task<BinancePayResult<PaymentResult>> ExecuteAuthorizedPayment(
        PaymentIdentification identification,
        PaymentOrder order,
        PaymentProduct product,
        PaymentOptionalMeta? meta = null,
        CancellationToken ct = default);
}
