using BinancePayConnector.MediatrStyle.Abstractions;
using BinancePayConnector.Models.C2B.RestApi.Payout.BatchPayout.Enums;

namespace BinancePayConnector.Models.C2B.RestApi.Payout.BatchPayout;

/// <summary>
/// You can see this in official documentation: <see href="https://developers.binance.com/docs/binance-pay/api-payout"/>
/// </summary>
/// <param name="RequestId">The unique ID assigned by the merchant to identify a payout request.</param>
/// <param name="BatchName">The name of the batch payout.</param>
/// <param name="Currency">All the transfers under this batch must use the same currency.</param>
/// <param name="TotalAmount">It must be equal to the sum of all the detail transfers.</param>
/// <param name="TotalNumber">The total number of transfers. It must be equal to the detail transfer count.</param>
/// <param name="TransferDetailList">Detail transfer list.</param>
/// <param name="BizScene">Describe the business scene of this payout. Limited to <see cref="BizSceneType"/>.</param>
public sealed record BatchPayoutRequest(
    string RequestId,
    string BatchName,
    string Currency,
    decimal TotalAmount,
    int TotalNumber,
    IEnumerable<TransferDetail> TransferDetailList,
    string? BizScene = null
) : IRequest<BatchPayoutResult>;
