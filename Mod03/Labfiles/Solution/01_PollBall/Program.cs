using PollBall.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IPollResultsService, PollResultsService>();
builder.Services.AddMvc();
var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var pollResults = services.GetRequiredService<IPollResultsService>();
    app.Use(async (context, next) =>
    {
        if (context.Request.Query.ContainsKey("favorite"))
        {
            string selectedValue = context.Request.Query["favorite"];
            SelectedGame selectedGame = (SelectedGame)Enum.Parse(typeof(SelectedGame), selectedValue, true);
            pollResults.AddVote(selectedGame);

            context.Response.Headers["content-type"] = "text/html";
            await context.Response.WriteAsync("Thank you for submitting the poll. You may look at the poll results <a href='/?submitted=true'>Here</a>.");
        }
        else
        {
            await next.Invoke();
        }
    });
}

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();
