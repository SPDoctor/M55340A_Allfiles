var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "firstRoute",
    "{controller}/{action}/{num:int}"
    );
app.MapControllerRoute(
    "secondRoute",
    "{controller}/{action}/{id?}",
    new { controller = "Home", action = "Index" }
    );
app.Run();