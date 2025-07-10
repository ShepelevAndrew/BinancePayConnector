using BinancePayConnector.Core.Clients.WebHookListener;
using BinancePayConnector.Services.Interfaces;

namespace BinancePayConnector;

public interface IBinancePay : IBinancePayReceiver
{
    IBinancePayOrderService Order { get; init; }

    IBinancePayTransferFundService TransferFund { get; init; }

    IBinancePaySubMerchantService SubMerchant { get; init; }

    IBinancePayWalletBalanceService WalletBalance { get; init; }

    IBinancePayDirectDebitService DirectDebit { get; init; }

    IBinancePayPayoutService Payout { get; init; }

    IBinancePayConvertService Convert { get; init; }

    IBinancePayReportingService Reporting { get; init; }

    IBinancePayProfitSharingService ProfitSharing { get; init; }

    IBinancePayShareInfoService ShareInfo { get; init; }

    IBinancePayTechnicalServiceProviderService TechnicalServiceProvider { get; init; }
}
