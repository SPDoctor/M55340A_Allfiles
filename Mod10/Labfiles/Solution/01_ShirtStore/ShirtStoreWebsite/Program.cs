using Microsoft.EntityFrameworkCore;
using Serilog;
using ShirtStoreWebsite.Data;
using ShirtStoreWebsite.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ShirtContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IShirtRepository, ShirtRepository>();
builder.Services.AddControllersWithViews();
builder.Logging.ClearProviders();
var config = builder.Configuration.GetSection("Logging");
if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddConfiguration(config);
    builder.Logging.AddConsole();
}
else
{
    builder.Logging.AddFile("shirt_store_logs.txt");
}
var app = builder.Build();
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error.html");
}
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    "defaultRoute",
    "{controller=Shirt}/{action=Index}/{id?}"
    );
app.Run();