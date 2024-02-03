using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using WebApp;
// using WebApp.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var authenticationBuilder = builder.Services.AddAuthentication(Constants.AuthTypeSchemeName);
authenticationBuilder.AddCookie(Constants.AuthTypeSchemeName, cookieAuthenticationOptions =>
{
    cookieAuthenticationOptions.Cookie.Name = Constants.AuthTypeSchemeName;
    cookieAuthenticationOptions.LoginPath = "/LoginLogout/LogIn";
    cookieAuthenticationOptions.AccessDeniedPath = "/AccessDenied";
    cookieAuthenticationOptions.ExpireTimeSpan = TimeSpan.FromSeconds(120);
    cookieAuthenticationOptions.SlidingExpiration = false;
});

var authorizationBuilder = builder.Services.AddAuthorization(authorizationOptions => {

    // authorizationOptions.AddPolicy("AdminOnly",
    //     policy => policy.RequireClaim("Admin"));

    authorizationOptions.AddPolicy("MustBelongToHrDept",
        policy => policy.RequireClaim("Dept", "Hr"));

    authorizationOptions.AddPolicy("ConfirmedEnggOnly", policy => policy
        .RequireClaim("Dept", "Engg")
        // .RequireClaim("")
        // .Requirements.Add(new EnggProbationRequirement(3))
        );
});

builder.Services.AddHttpClient(Constants.HttpApiLogicalName, client =>
{
    client.BaseAddress = new Uri("https://localhost:7038/");
});

// builder.Services.AddSingleton<IAuthorizationHandler, EnggProbationRequirementHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
