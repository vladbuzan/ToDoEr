using Infrastructure.Exceptions;
using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddToDoErDb(config.GetConnectionString("Db") ??
    throw new SetupException("Db connection string is not set"));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();