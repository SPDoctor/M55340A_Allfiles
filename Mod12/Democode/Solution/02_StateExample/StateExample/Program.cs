var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();