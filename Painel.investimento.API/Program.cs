using Microsoft.EntityFrameworkCore;
using Painel.investimento.API.Repository.Abstract;
using Painel.investimento.API.Repository.Concret;
using Painel.investimento.Infra.Data;
using Painel.Investimento.Aplication.Repository.Abstract;
using Painel.Investimento.Aplication.UserCases;
using System;

var builder = WebApplication.CreateBuilder(args);


// Lê a Connection String do appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRegistrarClienteAplicationRepository, RegistrarCliente>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
