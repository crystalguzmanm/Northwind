using Microsoft.EntityFrameworkCore;
using Northwind.Infrastructure.Context;
using Northwind.loc.Dependencies;

var builder = WebApplication.CreateBuilder(args);


//contexto
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext")));

builder.Services.AddCustomersDependencies();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
