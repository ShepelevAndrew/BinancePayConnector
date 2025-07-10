namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder;

/// <param name="SubMerchantId">
/// Sub-merchant id (issued when sub-merchant is created at binance). **Required for Channel Partner.**
/// Note: If you’re a Channel Partner and you’re placing order for your own business, you need to create a separate sub-merchant id accordingly.
/// </param>
public sealed record Merchant(
    string? SubMerchantId = null
);
