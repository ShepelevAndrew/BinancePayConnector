using BinancePayConnector;
using BinancePayConnectorSlim;

const string apiKey = "api-key";
const string apiSecret = "api-secret";

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddControllers();

    builder.Services.AddBinancePay(apiKey, apiSecret);
    builder.Services.AddBinancePaySlim(apiKey, apiSecret);
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();