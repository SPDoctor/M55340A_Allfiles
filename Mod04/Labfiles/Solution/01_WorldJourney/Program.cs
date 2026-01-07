using WorldJourney.Filters;
using WorldJourney.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IData, Data>();
builder.Services.AddScoped<LogActionFilterAttribute>();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "TravelerRoute",
    "{controller}/{action}/{name}",
    new { controller = "Traveler", action = "Index", name = "Katie Bruce" },
    new { name = "[A-Za-z ]+" }
    );
app.MapControllerRoute(
    "defaultRoute",
    "{controller}/{action}/{id?}",
    new { controller = "Home", action = "Index" },
    new { id = "[0-9]+" }
    );
app.Run();