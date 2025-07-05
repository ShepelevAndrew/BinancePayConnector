using BinancePayConnector.MediatrStyle.Abstractions;

namespace BinancePayConnector.Models.C2B.RestApi.Order.PaymentPayerVerification;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-order-payer-verification"/>
/// </summary>
/// <param name="BinanceId">Payer's binance id.</param>
/// <param name="PayerType">
/// Enum value from <see cref="Enums.PayerType"/>:<br/>
/// - INDIVIDUAL: Individual payer,<br/>
/// - CORPORATE: Corporate payer.
/// </param>
/// <param name="Information">Information will be verified.</param>
public sealed record PaymentPayerVerificationRequest(
    string BinanceId,
    string PayerType,
    List<Info>? Information = null
) : IRequest<bool?>;
