using SignalRExample.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISquareManager, SquareManager>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "Default",
    "{controller}/{action}",
    new { controller = "Square", action = "Index" });
app.Run();