using MapsterCard.ServiceProviders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAppService()
    .AddDatabase(builder.Configuration);


var app = builder.Build();

app.MapGet("/", () => "HelloWorld!");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();