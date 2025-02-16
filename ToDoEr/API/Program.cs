using Application.Abstractions.Services.CacheService;
using Application.Exceptions;
using Infrastructure.Exceptions;
using Infrastructure.Extensions;
using Infrastructure.Services.CacheService.Implementations;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();

builder.Services
    .AddToDoErDb(config.GetConnectionString("Db") ??
        throw new SetupException("Db connection string is not set"))
    .AddMapster()
    .AddMediatR()
    .AddRepositories()
    .AddRedisCache(config.GetConnectionString("Db") ??
        throw new SetupException("Db connection string is not set"))
    .AddSingleton<ICacheService, MessagePackCacheService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(cfg =>
    {
        cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoEr API");
        cfg.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();