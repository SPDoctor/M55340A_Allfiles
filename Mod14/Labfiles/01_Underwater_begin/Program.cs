using Microsoft.EntityFrameworkCore;
using Underwater.Data;
using Underwater.Middleware;
using Underwater.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IUnderwaterRepository, UnderwaterRepository>();
builder.Services.AddDbContext<UnderwaterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseStaticFiles();

app.UseNodeModules(app.Environment.ContentRootPath);

app.UseRouting();

app.MapControllerRoute(
    name: "UnderwaterRoute",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Aquarium", action = "Index" },
    constraints: new { id = "[0-9]+" }
);

app.Run();
