using LoggingExample.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ICounter, Counter>();
builder.Services.AddSingleton<IDivisionCalculator, DivisionCalculator>();
builder.Services.AddControllersWithViews();
builder.Logging.ClearProviders();
var config = builder.Configuration.GetSection("Logging");
if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddConfiguration(config);
    builder.Logging.AddConsole();
}
else
{
    builder.Logging.AddSerilog();
}
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();
