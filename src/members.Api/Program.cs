using members.Api.Extensions;
using members.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHealthChecks();

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureApplicationServices(builder.Configuration);

if (builder.Environment.IsDevelopment()) 
{
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMemberEndpoints();

app.MapHealthChecks("/health");

app.Run();

public partial class Program { }
