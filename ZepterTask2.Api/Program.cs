using Microsoft.EntityFrameworkCore;
using ZepterTask.Infrastructure.Repositories;
using ZepterTask.Infrastructure.Services;
using ZepterTask.Models.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
      b => b.MigrationsAssembly("ZepterTask.Infrastructure")));

builder.Services.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
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
