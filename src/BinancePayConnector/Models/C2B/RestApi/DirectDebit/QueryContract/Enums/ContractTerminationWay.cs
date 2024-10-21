namespace BinancePayConnector.Models.C2B.RestApi.DirectDebit.QueryContract.Enums;

public enum ContractTerminationWay
{
    ByUser = 0,
    AutoExpire = 1,
    ByOperationTeam = 2,
    ByMerchantOpenApi = 3
}
