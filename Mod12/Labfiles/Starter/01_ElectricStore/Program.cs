using ElectricStore.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite("Data Source=electricStore.db"));
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "ElectricStoreRoute",
    "{controller}/{action}/{id?}/{RefreshCache?}",
    new { controller = "Products", action = "Index" },
    new { id = "[0-9]+" });
app.Run();