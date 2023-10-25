using Northwind.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Repositories;
using Northwind.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Northwind.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);





//Agregar dependencias del context //
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext")));


//Dependecia de los repositorios//
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
