var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "RestaurantRoute",
    "{controller}/{action}/{id?}",
    new { controller = "RestaurantBranches", action = "Index" },
    new { id = "[0-9]+" }
    );
app.Run();