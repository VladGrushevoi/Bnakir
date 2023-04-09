using MapsterCard.AppDbContext;
using MapsterCard.ServiceProviders;
using MapsterCard.ServiceProviders.Extension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAppService()
    .AddDatabase(builder.Configuration);

var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
dataContext.Database.EnsureCreated();

app.MapGroup("/card")
    .MapSystemCard()
    .WithTags("Public");
app.MapGroup("/system")
    .RouteSystemGroup()
    .WithTags("System");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader();
    opt.AllowAnyMethod();
    opt.AllowAnyOrigin();
});

app.Run();