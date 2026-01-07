using LayoutExample.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "Data Source=student.db";
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "StudentRoute",
    "{controller}/{action}/{id?}",
    new { controller = "Student", action = "Index" },
    new { id = "[0-9]+" }
    );
app.Run();