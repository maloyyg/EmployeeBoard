using Microsoft.EntityFrameworkCore;
using EmployeeBoard.Services;
using EmployeeBoard.Repositories;
using EmployeeBoard.WebAPI.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<GlobalExceptionHandlerMiddleware>();
builder.Services.ConfigureServices();
string dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.ConfigureRepositories(dbConnectionString);
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.Run();
