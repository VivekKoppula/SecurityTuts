using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using WebAppWpCustomRequirement;
using WebAppWpCustomRequirement.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var authenticationBuilder = builder.Services.AddAuthentication(Constants.AuthTypeSchemeName);
authenticationBuilder.AddCookie(Constants.AuthTypeSchemeName, options =>
{
    options.Cookie.Name = Constants.AuthTypeSchemeName;
    options.LoginPath = "/LoginLogout/LogIn";
    options.AccessDeniedPath = "/AccessDenied";
    // options.LogoutPath = "/Account/LogOff";
});

var authorizationBuilder = builder.Services.AddAuthorization(authorizationOptions => {

    // authorizationOptions.AddPolicy("AdminOnly",
    //     policy => policy.RequireClaim("Admin"));

    authorizationOptions.AddPolicy("MustBelongToHrDept",
        policy => policy.RequireClaim("Dept", "Hr"));

    authorizationOptions.AddPolicy("ConfirmedEnggOnly", policy => policy
        .RequireClaim("Dept", "Engg")
        // .RequireClaim("")
        .Requirements.Add(new EnggProbationRequirement(3)));
});

builder.Services.AddSingleton<IAuthorizationHandler, EnggProbationRequirementHandler>();

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
