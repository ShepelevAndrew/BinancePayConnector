using BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.Enums;

namespace BinancePayConnector.Core.Models.C2B.RestApi.Order.CreateOrder.GoodsModel;

/// <param name="GoodsType">The type of the goods for the order: Enum values from <see cref="Enums.GoodsType"/>.</param>
/// <param name="GoodsCategory">Enum values from: <see cref="Enums.GoodsCategory"/>.</param>
/// <param name="ReferenceGoodsId">The unique ID to identify the goods.</param>
/// <param name="GoodsName">Goods name. Special character is prohibited Example: \ " or emoji.</param>
/// <param name="GoodsDetail">Some description for goods.</param>
/// <param name="GoodsUnitAmount">Price of goods.</param>
public sealed record Goods(
    string GoodsType,
    string GoodsCategory,
    string ReferenceGoodsId,
    string GoodsName,
    string? GoodsDetail = null,
    GoodsUnitAmount? GoodsUnitAmount = null
);
