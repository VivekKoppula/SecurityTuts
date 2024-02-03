using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.Use(MiddleWareOne);

app.Use(MiddleWareTwo);

app.Use(MiddleWareThree);

app.Run();


async Task MiddleWareOne(HttpContext context, Func<Task> next)
{
    Console.WriteLine("111 - Enter");
    await next.Invoke();
    Console.WriteLine("111 - Exit");
}

async Task MiddleWareTwo(HttpContext context, Func<Task> next)
{
    Console.WriteLine("     222 - Enter");
    await next.Invoke();
    Console.WriteLine("     222 - Exit");
}

async Task MiddleWareThree(HttpContext context, Func<Task> next)
{
    Debugger.Break();

    var identities = context.User.Identities;

    foreach (var identity in identities)
    {
        Console.WriteLine($"The identity is {identity.Name}");
        Console.WriteLine($"The is Authenticated for the identity is {identity.IsAuthenticated}");
    }

    Console.WriteLine("         333 - Enter");
    await context.Response.WriteAsync("Hello !!!!");
    Console.WriteLine("         333 - Exit");
    Debugger.Break();
}
