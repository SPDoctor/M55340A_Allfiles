using ElectricStore.Data;
using Microsoft.EntityFrameworkCore;
using ElectricStore.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite("Data Source=electricStore.db"));
builder.Services.AddSession(
    options => options.IdleTimeout = TimeSpan.FromSeconds(60));
builder.Services.AddSignalR();

var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.MapHub<ChatHub>("/chatHub");
app.UseRouting();
app.MapControllerRoute(
    "ElectricStoreRoute",
    "{controller}/{action}/{id?}/{RefreshCache?}",
    new { controller = "Products", action = "Index" },
    new { id = "[0-9]+" });
app.Run();