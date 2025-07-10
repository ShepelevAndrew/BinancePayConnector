using BinancePayConnector.Core.Models.Abstractions;

namespace BinancePayConnector.Core.Models.C2B.RestApi.ProfitSharing.SubmitSplit;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-profitshare-submit-split#request-parameters"/>.
/// </summary>
public sealed record SubmitSplitRequest(
    string MerchantRequestId,
    string PrepayOrderId,
    IEnumerable<Receiver> ReceiverList
) : IRequest<SubmitSplitResult>;
