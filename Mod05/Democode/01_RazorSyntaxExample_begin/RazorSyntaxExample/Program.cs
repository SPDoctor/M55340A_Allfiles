var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "secondRoute",
    "{controller}/{action}/{id?}",
    new { controller = "Product", action = "Index" }
    );
app.Run();