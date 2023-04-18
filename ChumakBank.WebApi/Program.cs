using ChumakBank.WebApi;
using ChumakBank.WebApi.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureWebApi(builder.Configuration);

var app = builder.Build();

app.MigrateDatabase();
app.ConfigurePipeline();

app.Run();