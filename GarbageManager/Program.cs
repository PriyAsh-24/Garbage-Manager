using Microsoft.EntityFrameworkCore;
using GarbageManager.Models;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GarbageDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections")));


var app = builder.Build();

var env = app.Environment.ContentRootPath;
RotativaConfiguration.Setup(env, "wwwroot/Rotativa");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

