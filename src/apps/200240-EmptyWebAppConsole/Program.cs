using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.Use(async (context, next) =>
{
    Console.WriteLine("111 - Enter");
    await next.Invoke();
    Console.WriteLine("111 - Exit");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("     222 - Enter");
    await next.Invoke();
    Console.WriteLine("     222 - Exit");
});

app.Run(async context =>
{
    // Debugger.Break();
    Console.WriteLine("         333 - Enter");
    await context.Response.WriteAsync("Hello !!!!");
    Console.WriteLine("         333 - Exit");
    // Debugger.Break();
});

app.Run();
