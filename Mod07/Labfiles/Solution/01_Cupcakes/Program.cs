using Cupcakes.Data;
using Cupcakes.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CupcakeContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<ICupcakeRepository, CupcakeRepository>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "CupcakeRoute",
    "{controller}/{action}/{id?}",
    new { controller = "Cupcake", action = "Index" },
    new { id = "[0-9]+" }
    );
app.Run();