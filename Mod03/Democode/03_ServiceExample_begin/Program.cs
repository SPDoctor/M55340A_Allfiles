var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); 
var app = builder.Build();

//app.MapGet("/Hello", () => "Hello World!");
app.MapRazorPages();
app.Run();
