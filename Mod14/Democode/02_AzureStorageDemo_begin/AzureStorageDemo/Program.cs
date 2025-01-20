using Microsoft.EntityFrameworkCore;
using AzureStorageDemo.Middleware;
using AzureStorageDemo.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PhotoContext>(options =>
    options.UseSqlite("Data Source=photoDb.db"));

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.Run();
