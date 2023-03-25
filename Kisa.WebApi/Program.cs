using Kisa.WebApi;
using Kisa.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApiServices(builder.Configuration);

var app = builder.Build();

app.ConfigureApi();

app.Run();