using Microsoft.EntityFrameworkCore;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Repositories;
using Northwind.loc.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add context dependency.
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null
            );
    }
    ));

// Repository dependencies.
//builder.Services.AddTransient<ICustomersRepository,CustomersRepository>();

builder.Services.AddCustomersDependencies();

// App services dependencies.

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
