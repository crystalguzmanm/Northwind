using Northwind.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Repositories;
using Northwind.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Northwind.Infrastructure.Interfaces;
using Northwind.loc.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();



//Agregar dependencias del context //
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext")));


//Dependecia de los repositorio//

//builder.Services.AddTransient<IOrdersRepository, OrdersRepository>(); Ya esta en el loc

builder.Services.AddOrdersDependecy();

builder.Services.AddTransient<IOrdersDetailsRepository, OrdersDetailsRepository>();

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
