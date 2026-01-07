using Microsoft.EntityFrameworkCore;
using GridExample.Data;
using GridExample.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ChessLeagueContext>(options =>
    options.UseSqlite("Data Source=chessLeague.db"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseNodeModules(app.Environment.ContentRootPath);

app.UseRouting();

app.MapControllerRoute(
    name: "ChessRoute",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Chess", action = "Index" },
    constraints: new { id = "[0-9]+" }
);

app.Run();
