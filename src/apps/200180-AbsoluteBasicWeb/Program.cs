var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    System.Console.WriteLine("Request path");
    await next.Invoke();
    System.Console.WriteLine("Reponse path");
});

app.MapGet("/", () => "Hello World!");

app.Run();
