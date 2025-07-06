using BinancePayConnector.Models.C2B.RestApi.Order.CreateOrder;

namespace BinancePayConnector.Services.Models.Order.CreateOrder;

public record OrderFeatures(
    DirectDebitContract? DirectDebitContract = null,
    OrderTags? OrderTags = null,
    string? PassThroughInfo = null,
    string? VoucherCode = null
);