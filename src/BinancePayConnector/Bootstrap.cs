using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Config.Options;
using BinancePayConnector.Services;
using BinancePayConnector.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BinancePayConnector;

public static class Bootstrap
{
    public static IServiceCollection AddBinancePay(
        this IServiceCollection services,
        string apiKey,
        string apiSecret)
    {
        services.AddBinancePayConfig(apiKey, apiSecret);
        services.AddBinancePayLogic();

        return services;
    }

    public static IServiceCollection AddBinancePay(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddBinancePayConfig(config);
        services.AddBinancePayLogic();

        return services;
    }

    private static void AddBinancePayLogic(
        this IServiceCollection services)
    {
        services.AddScoped<IBinancePayClient, BinancePayClient>();
        services.AddScoped<IBinancePay, BinancePay>();
        services.AddBinancePayServices();
    }

    private static void AddBinancePayServices(this IServiceCollection services)
        => services.AddScoped<IBinancePayOrderService, BinancePayOrderService>()
            .AddScoped<IBinancePayTransferFundService, BinancePayTransferFundService>()
            .AddScoped<IBinancePaySubMerchantService, BinancePaySubMerchantService>()
            .AddScoped<IBinancePayWalletBalanceService, BinancePayWalletBalanceService>()
            .AddScoped<IBinancePayDirectDebitService, BinancePayDirectDebitService>()
            .AddScoped<IBinancePayPayoutService, BinancePayPayoutService>()
            .AddScoped<IBinancePayConvertService, BinancePayConvertService>()
            .AddScoped<IBinancePayReportingService, BinancePayReportingService>()
            .AddScoped<IBinancePayProfitSharingService, BinancePayProfitSharingService>()
            .AddScoped<IBinancePayShareInfoService, BinancePayShareInfoService>()
            .AddScoped<IBinancePayTechnicalServiceProviderService, BinancePayTechnicalServiceProviderService>();

    private static void AddBinancePayConfig(
        this IServiceCollection services,
        string apiKey,
        string apiSecret)
        => services.Configure<BinancePayConfig>(options =>
        {
            options.ApiKey = apiKey;
            options.ApiSecret = apiSecret;
        });

    private static void AddBinancePayConfig(
        this IServiceCollection services,
        IConfiguration config)
        => services.Configure<BinancePayConfig>(config.GetSection(BinancePayConfig.BinancePay));
}
