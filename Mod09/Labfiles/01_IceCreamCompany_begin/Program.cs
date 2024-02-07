using IceCreamCompany.Data;
using IceCreamCompany.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<IceCreamContext>(options =>
     options.UseSqlite("Data Source=iceCream.db"));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepository, Repository>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "IceCreamRoute",
    "{controller}/{action}/{id?}",
    new { controller = "IceCream", action = "Index" },
    new { id = "[0-9]+" }
    );
app.Run();