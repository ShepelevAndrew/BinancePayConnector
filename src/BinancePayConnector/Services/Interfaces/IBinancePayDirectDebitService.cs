using BinancePayConnector.Models.C2B.RestApi.DirectDebit.CreateContract;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.Payment;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.PaymentNotification;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.QueryContract;
using BinancePayConnector.Models.C2B.RestApi.DirectDebit.TerminateContract;
using BinancePayConnector.Services.Models.Result;

namespace BinancePayConnector.Services.Interfaces;

public interface IBinancePayDirectDebitService
{
    Task<BinancePayResult<CreateContractResult>> CreateContract(
        CreateContract request,
        CancellationToken ct = default);

    Task<BinancePayResult<QueryContractResult>> QueryContract(
        QueryContract request,
        CancellationToken ct = default);

    Task<BinancePayResult<bool?>> TerminateContract(
        TerminateContract request,
        CancellationToken ct = default);

    Task<BinancePayResult<PaymentNotificationResult>> PaymentNotify(
        PaymentNotification request,
        CancellationToken ct = default);

    Task<BinancePayResult<PaymentResult>> AuthorizationPay(
        Payment request,
        CancellationToken ct = default);
}
