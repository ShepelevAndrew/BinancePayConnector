using BinancePayConnector.Core.Models.C2B.Common.Enums;
using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Convert.SendQuote;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-convert-get-quote#request-parameters"/>
/// </summary>
/// <param name="Wallet">
/// Enum value from <see cref="Common.Enums.WalletType" /><br/>
/// - FUNDING_WALLET<br/>
/// - SPOT_WALLET
/// </param>
/// <param name="FromAsset">Currency to query from <see cref="Assets"/>, for e.g, USDT</param>
/// <param name="ToAsset">Currency to query from <see cref="Assets"/>, for e.g, USDT</param>
/// <param name="FromAmount">From asset amount</param>
/// <param name="ToAmount">To asset amount</param>
public sealed record SendQuoteRequest(
    string Wallet,
    string FromAsset,
    string ToAsset,
    decimal? FromAmount,
    decimal ToAmount
) : IRequest<SendQuoteResult>;
