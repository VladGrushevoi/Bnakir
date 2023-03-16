using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MapsterCard.ServiceProviders;
using MapsterCard.ServiceProviders.Extension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAppService()
    .AddDatabase(builder.Configuration);

var app = builder.Build();

app.MapGroup("/card")
    .MapSystemCard()
    .WithTags("Public");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();