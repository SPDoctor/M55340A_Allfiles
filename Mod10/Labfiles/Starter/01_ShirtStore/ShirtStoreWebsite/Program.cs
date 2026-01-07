using Microsoft.EntityFrameworkCore;
using ShirtStoreWebsite.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ShirtContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "defaultRoute",
    "{controller=Shirt}/{action=Index}/{id?}"
    );
app.Run();