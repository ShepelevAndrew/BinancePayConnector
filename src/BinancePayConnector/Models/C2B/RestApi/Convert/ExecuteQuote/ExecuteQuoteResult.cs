using BinancePayConnector.Models.C2B.Common.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.Convert.ExecuteQuote;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-convert-execute-quote#acceptquoteresp"/>.
/// </summary>
/// <param name="OrderId">Order id of the executed convert order.</param>
/// <param name="CreateTime">Timestamp order created.</param>
/// <param name="OrderStatus">SUCCESS/FAIL/PROCESS.</param>
/// <param name="QuotePrice">From:To quote price.</param>
/// <param name="InversePrice">To:From quote price.</param>
/// <param name="FromCoin">From Asset. Enum values from: <see cref="Assets"/>.</param>
/// <param name="FromCoinAmount">Amount debited.</param>
/// <param name="ToCoin">To Asset. Enum values from: <see cref="Assets"/>.</param>
/// <param name="ToCoinAmount">Amount credited.</param>
public sealed record ExecuteQuoteResult(
    string OrderId,
    decimal CreateTime,
    string OrderStatus,
    decimal QuotePrice,
    decimal InversePrice,
    string FromCoin,
    decimal FromCoinAmount,
    string ToCoin,
    decimal ToCoinAmount
);
