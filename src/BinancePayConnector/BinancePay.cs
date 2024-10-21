using BinancePayConnector.Clients;
using BinancePayConnector.Clients.WebHookListener;
using BinancePayConnector.Config.Options;
using BinancePayConnector.Models.C2B.Common.Enums;
using BinancePayConnector.Models.C2B.Webhook.Common;
using BinancePayConnector.Services;
using BinancePayConnector.Services.Interfaces;

namespace BinancePayConnector;

public class BinancePay : IBinancePay
{
    private readonly IBinancePayReceiver? _binancePayReceiver;
    private readonly BinancePayWebhookConfig? _webhookConfig;

    public BinancePay(
        string apiKey,
        string apiSecret)
    {
        var binancePayClient = new BinancePayClient(apiKey, apiSecret);

        Order = new BinancePayOrderService(binancePayClient);
        TransferFund = new BinancePayTransferFundService(binancePayClient);
        SubMerchant = new BinancePaySubMerchantService(binancePayClient);
        WalletBalance = new BinancePayWalletBalanceService(binancePayClient);
        DirectDebit = new BinancePayDirectDebitService(binancePayClient);
        Payout = new BinancePayPayoutService(binancePayClient);
        Convert = new BinancePayConvertService(binancePayClient);
        Reporting = new BinancePayReportingService(binancePayClient);
        ProfitSharing = new BinancePayProfitSharingService(binancePayClient);
        ShareInfo = new BinancePayShareInfoService(binancePayClient);
        TechnicalServiceProvider = new BinancePayTechnicalServiceProviderService(binancePayClient);
    }

    public BinancePay(
        IBinancePayReceiver binancePayReceiver,
        IBinancePayOrderService orderService,
        IBinancePayTransferFundService transferFundService,
        IBinancePaySubMerchantService subMerchantService,
        IBinancePayWalletBalanceService walletBalanceService,
        IBinancePayDirectDebitService directDebit,
        IBinancePayPayoutService payout,
        IBinancePayConvertService convert,
        IBinancePayReportingService reporting,
        IBinancePayProfitSharingService profitSharing,
        IBinancePayShareInfoService shareInfo,
        IBinancePayTechnicalServiceProviderService technicalServiceProvider)
    {
        _binancePayReceiver = binancePayReceiver;

        Order = orderService;
        TransferFund = transferFundService;
        SubMerchant = subMerchantService;
        WalletBalance = walletBalanceService;
        DirectDebit = directDebit;
        Payout = payout;
        Convert = convert;
        Reporting = reporting;
        ProfitSharing = profitSharing;
        ShareInfo = shareInfo;
        TechnicalServiceProvider = technicalServiceProvider;
    }

    public BinancePayWebhookConfig? WebhookConfig
    {
        get => _webhookConfig;
        init
        {
            if (_webhookConfig != null)
                throw new InvalidOperationException("WebhookConfig is already set.");

            _webhookConfig = value ?? throw new ArgumentNullException(nameof(value));
            _binancePayReceiver = new BinancePayReceiver(_webhookConfig);
        }
    }

    public IBinancePayOrderService Order { get; init; }

    public IBinancePayTransferFundService TransferFund { get; init; }

    public IBinancePaySubMerchantService SubMerchant { get; init; }

    public IBinancePayWalletBalanceService WalletBalance { get; init; }

    public IBinancePayDirectDebitService DirectDebit { get; init; }

    public IBinancePayPayoutService Payout { get; init; }

    public IBinancePayConvertService Convert { get; init; }

    public IBinancePayReportingService Reporting { get; init; }

    public IBinancePayProfitSharingService ProfitSharing { get; init; }

    public IBinancePayShareInfoService ShareInfo { get; init; }

    public IBinancePayTechnicalServiceProviderService TechnicalServiceProvider { get; init; }

    public void OnUpdateInvoke(Action<WebHookRequest> callback)
    {
        _binancePayReceiver?.OnUpdateInvoke(callback);
    }

    public void OnUpdateInvoke(Action<WebHookRequest> callback, string name)
    {
        _binancePayReceiver?.OnUpdateInvoke(callback, name);
    }

    public void OnUpdateInvoke(Func<WebHookRequest, ResponseType> callback, string name)
    {
        _binancePayReceiver?.OnUpdateInvoke(callback, name);
    }

    public async Task StopReceiving()
    {
        if(_binancePayReceiver is not null)
            await _binancePayReceiver.StopReceiving();
    }
}
