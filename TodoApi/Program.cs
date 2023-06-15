using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Middlewares;
using TodoApi.Services;
using TodoApi.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var config = builder.Configuration;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddControllers();

services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining<Program>();

services.AddDbContext<TodoDbContext>(options => options.UseSqlServer(config.GetConnectionString("SqlServer")));
services.AddTransient<ITodoService, TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();