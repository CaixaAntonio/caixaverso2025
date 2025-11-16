using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Painel.investimento.API.Mapper;
using Painel.investimento.Infra.Data;
using Painel.investimento.Infra.Repositorie;
using Painel.Investimento.Aplication.UserCases;
using Painel.investimento.API.ViewModels.Validators;
using FluentValidation;
using Painel.Investimento.Domain.Repository.Abstract;
using Painel.Investimento.Aplication.Repository.Abstract;
using Painel.Investimento.Infra.Repositorie;
using Painel.Investimento.API.Mapper;
using Painel.Investimento.API.ViewModels.Validators;
using Painel.Investimento.Infra.Repository;
using Painel.Investimento.API.Mappings;


var builder = WebApplication.CreateBuilder(args);


// Lê a Connection String do appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// UseCases
builder.Services.AddScoped<ProdutoInvestimentoUseCase>();
builder.Services.AddScoped<ClienteUseCase>();
builder.Services.AddScoped<PerfilProdutoUseCase>();

//Repository

builder.Services.AddScoped<IPerfilProdutoRepository, PerfilProdutoRepository>();
builder.Services.AddScoped<IProdutoInvestimentoRepository, ProdutoInvestimentoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(ProdutoInvestimentoProfile));
builder.Services.AddAutoMapper(typeof(PerfilProdutoProfile));



// Registro do FluentValidation moderno
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Registro dos Validators
builder.Services.AddValidatorsFromAssemblyContaining<ProdutoInvestimentoRequestValidator>();

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
