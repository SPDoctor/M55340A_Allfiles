using MiddlewareExample.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ILog, Log>();
var app = builder.Build();

//app.MapGet("/Hello", () => "Hello World!");
app.MapRazorPages();
app.Run();
