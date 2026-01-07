using Microsoft.EntityFrameworkCore;
using ZooSite.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ZooContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "ZooRoute",
    "{controller}/{action}/{id?}",
    new { controller = "Zoo", action = "Index" },
    new { id = "[0-9]+" }
    );
app.Run();