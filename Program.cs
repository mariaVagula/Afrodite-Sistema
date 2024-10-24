using Afrodite_Sistema.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>
<<<<<<< HEAD
    (options => options.UseSqlServer("Data Source=SB-1490646\\SQLSENAI;Initial Catalog = Afrodite-Sistema;Integrated Security = True;TrustServerCertificate = True"));
=======
    (options => options.UseSqlServer("Data Source=SB-1490625\\SQLSENAI;Initial Catalog = Afrodite-Sistema;Integrated Security = True;TrustServerCertificate = True"));
>>>>>>> 58184bb237b15c7f850f3964b4e9fd379241ef92

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
