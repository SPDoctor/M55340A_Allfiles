using Microsoft.AspNetCore.Identity;
using IdentityExample.Data;
using IdentityExample.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlite("Data Source=student.db"));
builder.Services.AddDefaultIdentity<Student>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 7;
    options.Password.RequireUppercase = true;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<StudentContext>();
builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.MapControllerRoute(
    "StudentRoute",
    "{controller}/{action}/{id?}",
    new { controller = "Student", action = "Index" },
    new { id = "[0-9]+" }
    );
app.Run();