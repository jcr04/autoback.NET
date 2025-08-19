using autoback.application.Common;
using autoback.application.Common.Behaviors;
using autoback.application.Common.Mapping;
using autoback.domain.Interfaces;
using autoback.infra.Data;
using autoback.infra.Repositories;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// SQL Server
builder.Services.AddDbContext<AutobackContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly));

// FluentValidation (varre o assembly do application)
builder.Services.AddValidatorsFromAssembly(typeof(AssemblyMarker).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Repositórios
builder.Services.AddScoped<IPecaRepository, PecaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IFabricanteRepository, FabricanteRepository>();

// Mapster
builder.Services.AddMapster();
MapsterConfig.Register();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var policy = "_allowFrontend";
builder.Services.AddCors(opt =>
    opt.AddPolicy(policy, p => p
        .WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy);
app.MapControllers();
app.Run();
