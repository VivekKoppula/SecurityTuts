using System.Diagnostics;
using WebAppAuthorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


var authBuilder = builder.Services.AddAuthentication(Constants.AuthTypeSchemeName);
authBuilder.AddCookie(Constants.AuthTypeSchemeName, options =>
{
    options.Cookie.Name = Constants.AuthTypeSchemeName;
    options.LoginPath = "/LoginLogout/LogIn";
    // options.LogoutPath = "/Account/LogOff";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    // Console.WriteLine($"The authenticated status {context.User.Identity!.IsAuthenticated}");
    await next.Invoke();
    Console.WriteLine($"The authenticated status 1 {context.User.Identity!.IsAuthenticated}");
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.Use(async (context, next) =>
{
    // Console.WriteLine($"The authenticated status {context.User.Identity!.IsAuthenticated}");
    await next.Invoke();
    Console.WriteLine($"The authenticated status 2 {context.User.Identity!.IsAuthenticated}");
});

app.UseAuthentication();

app.Use(async (context, next) =>
{
    // Console.WriteLine($"The authenticated status {context.User.Identity!.IsAuthenticated}");
    await next.Invoke();
    Console.WriteLine($"The authenticated status 3 {context.User.Identity!.IsAuthenticated}");
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
