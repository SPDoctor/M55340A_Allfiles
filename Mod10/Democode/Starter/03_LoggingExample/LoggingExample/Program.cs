using LoggingExample.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ICounter, Counter>();
builder.Services.AddSingleton<IDivisionCalculator, DivisionCalculator>();
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();
