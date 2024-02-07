using Microsoft.EntityFrameworkCore;
using ProductsWebsite.Data;
using ProductsWebsite.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "defaultRoute",
    "{controller=Product}/{action=Index}/{id?}"
    );
app.Run();