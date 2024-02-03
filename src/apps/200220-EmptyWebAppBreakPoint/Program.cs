using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");


app.Use(async (context, next) =>
{
    Debugger.Break();
    await next.Invoke();
    Debugger.Break();
});

app.Use(async (context, next) =>
{
    Debugger.Break();
    await next.Invoke();
    Debugger.Break();
});

app.Run(async context =>
{
    Debugger.Break();
    await context.Response.WriteAsync("Hello Breakpoint !!!!");
    Debugger.Break();
});

app.Run();
