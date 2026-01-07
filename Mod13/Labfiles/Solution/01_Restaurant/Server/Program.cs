using Microsoft.EntityFrameworkCore;
using Server.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlite("Data Source=restaurant.db"));
builder.Services.AddCors(options => options.AddPolicy("AllowAll",
    p => p.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()));

var app = builder.Build();
app.UseStaticFiles();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();