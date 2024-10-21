using BinancePayConnector;

const string apiKey = "xz4t6ccz71826dprluewhkyc8of39iypbykadjx8qljfuy293nfsojtsid5zofwh";
const string apiSecret = "ishrrq2x8anvwh8yphuxbpivwacb32btk3xsmk6agtxtuvlur1hbydo63zo7bect";

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddControllers();

    builder.Services.AddBinancePay(apiKey, apiSecret);
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();