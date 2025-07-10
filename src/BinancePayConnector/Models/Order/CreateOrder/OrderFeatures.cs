using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder;

namespace BinancePayConnector.Models.Order.CreateOrder;

public record OrderFeatures(
    DirectDebitContract? DirectDebitContract = null,
    OrderTags? OrderTags = null,
    string? PassThroughInfo = null,
    string? VoucherCode = null
);