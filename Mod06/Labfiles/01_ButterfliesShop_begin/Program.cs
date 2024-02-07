using ButterfliesShop.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IDataService, DataService>();
builder.Services.AddSingleton<IButterfliesQuantityService, ButterfliesQuantityService>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "ButterflyRoute",
    "{controller}/{action}/{id?}",
    new { controller = "Butterfly", action = "Index" },
    new { id = "[0-9]+" }
    );
app.Run();