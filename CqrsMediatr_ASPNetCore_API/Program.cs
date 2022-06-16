using CqrsMediatr_ASPNetCore_API.Behaviors;
using CqrsMediatr_ASPNetCore_API.Models;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddSingleton<FakeDataStore>();
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
