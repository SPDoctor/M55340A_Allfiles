﻿using ErrorHandlingExample.Services;
using Microsoft.AspNetCore.Http.Extensions;

ICounter cnt = new Counter();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IDivisionCalculator, DivisionCalculator>();
builder.Services.AddSingleton<ICounter, Counter>();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.Use(async (context, next) =>
{
    cnt.IncrementRequestPathCount(context.Request.GetDisplayUrl());
    await next.Invoke();
});
app.MapDefaultControllerRoute();
app.Run();