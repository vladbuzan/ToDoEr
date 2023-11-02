using Business.Extensions;
using Infrastructure.Exceptions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddToDoErDb(config.GetConnectionString("Db") ??
    throw new SetupException("Db connection string is not set"));

builder.Services
    .AddMapster()
    .AddMediatR()
    .AddRepositories();

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