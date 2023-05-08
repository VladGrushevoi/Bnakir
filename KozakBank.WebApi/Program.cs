using KozakBank.WebApi;
using KozakBank.WebApi.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApiServices(builder.Configuration);

var app = builder.Build();

app.ConfigureWebApiMiddlewares();

app.Run();