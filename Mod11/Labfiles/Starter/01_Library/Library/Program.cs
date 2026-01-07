using Microsoft.EntityFrameworkCore;
using Library.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite("Data Source=library.db"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    "LibraryRoute",
    "{controller}/{action}/{id?}",
    new { controller = "Home", action = "Index" },
    new { id = "[0-9]+" }
    );

app.Run();
