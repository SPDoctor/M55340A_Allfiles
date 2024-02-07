using CitiesWebsite.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICityProvider, CityProvider>();
builder.Services.AddSingleton<ICityFormatter, CityFormatter>();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "Default",
    "{controller}/{action}",
    new { controller = "City", action = "ShowCities" }
    );
app.Run();