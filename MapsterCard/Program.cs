using MapsterCard.AppDbContext.Entities;
using MapsterCard.AppDbContext.Repositories.Interfaces;
using MapsterCard.ServiceProviders;
using MapsterCard.ServiceProviders.Extension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAppService()
    .AddDatabase(builder.Configuration);

var app = builder.Build();
var scope = app.Services.CreateScope();
app.MapGroup("/card")
    .MapSystemCard(scope.ServiceProvider.GetRequiredService<ISystemCard>())
    .WithTags("Public");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();