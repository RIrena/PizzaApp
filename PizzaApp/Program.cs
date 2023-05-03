using Microsoft.EntityFrameworkCore;
using PizzaApp.Application.Repository;
using PizzaApp.Application.Services;
using PizzaApp.Application.Services.ExternalServices;
using PizzaApp.Application.Services.Implementation;
using PizzaApp.Domain.Models;
using PizzaApp.EntityFramework;
using PizzaApp.EntityFramework.Repository;
using PizzaApp.Infrastracture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IRepository<Order>, OrderRepository>();
//builder.Services.AddSingleton<IRepository<Pizza>, PizzaRepository>();
//builder.Services.AddSingleton<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<User>, BaseRepository<User>>();
builder.Services.AddScoped<IRepository<Order>, BaseRepository<Order>>();
builder.Services.AddScoped<IRepository<Pizza>, BaseRepository<Pizza>>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddDbContext<ApplicationDbContext>(ops => 
    ops.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

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
