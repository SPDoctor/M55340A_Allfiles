using Microsoft.EntityFrameworkCore;
using PhotoSharingSample.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PhotoSharingDB>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("PhotoSharingContext")));
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();