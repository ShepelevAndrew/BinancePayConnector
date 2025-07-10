using BinancePayConnector.Core.Clients;
using BinancePayConnector.Core.Config.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BinancePayConnectorSlim;

public static class Bootstrap
{
    public static IServiceCollection AddBinancePaySlim(
        this IServiceCollection services,
        string apiKey,
        string apiSecret)
    {
        services.AddBinancePayConfig(apiKey, apiSecret);
        services.AddBinancePaySlimLogic();

        return services;
    }

    public static IServiceCollection AddBinancePaySlim(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddBinancePayConfig(config);
        services.AddBinancePaySlimLogic();

        return services;
    }

    private static void AddBinancePaySlimLogic(
        this IServiceCollection services)
    {
        services.AddScoped<IBinancePayClient, BinancePayClient>();
        services.AddScoped<IBinancePaySlim, BinancePaySlim>();
    }

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
