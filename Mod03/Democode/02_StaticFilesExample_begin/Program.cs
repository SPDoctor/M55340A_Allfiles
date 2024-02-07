var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); 
var app = builder.Build();

//app.MapGet("/Hello", () => "Hello World!");
app.UseStaticFiles();
app.MapRazorPages();
app.Run();
