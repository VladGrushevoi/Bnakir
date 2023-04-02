using Shklift.WebApi;
using Shklift.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureWebApi(builder.Configuration);

var app = builder.Build();

app.ConfigurePipeline();

app.Run();