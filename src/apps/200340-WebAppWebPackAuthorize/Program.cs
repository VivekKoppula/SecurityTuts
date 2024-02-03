using System.Diagnostics;
using WebAppWebPackAuthorize;

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
// app.UseAuthorization();

app.MapRazorPages();

app.Run();
