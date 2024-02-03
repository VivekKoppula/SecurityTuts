# Introduces Authorization Service(not Authentication).

- This builds from the previous example.

- The previous example adds Authorization and Authentication middle ware. Now in this example, we will add Authorization service.

- We added **[Authorize]** attribute to Index page. See Index.cshtml.cs file(IndexModel class)

- Here we will know, what a policy is.

- Requirements are assigned to Policies and policies are applied to Authorize pages.

- Also In the program.cs file, you can see the following. And these are middle ware and not services.
```cs
app.UseAuthentication();
app.UseAuthorization();
```

- In this example we will add Authorization service to the DI Container(IServiceCollection)

- Steps
- First Add a HR page.
- Next Apply a Authorization policy on to the HR Page. Here we also specifying a policy, MustBelongToHrDept

```cs
[Authorize(Policy = "MustBelongToHrDept")]
public class HrModel : PageModel
{
    ... 
}
```

- Next Add a link to Hr page in the layout so we can click that HR link to access that page.

```html
<li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-page="/Hr">Hr</a>
</li>
```

- Define an Authorization Service and a policy. Note that the policy name(MustBelongToHrDept) matches the one in the Authorize attribute on the hr page(see above). 

```cs
var authorizationBuilder = builder.Services.AddAuthorization(authorizationOptions => {

    authorizationOptions.AddPolicy("MustBelongToHrDept",
        policy => policy.RequireClaim("Dept", "HR"));

});
```

- Now run. Login as required(admin, 123(password)) and then try to access the hr page. 
- When we are logging in, we are setting some claims. See the login page

```cs
var claims = new List<Claim> {
    new Claim(ClaimTypes.Name, "admin"),
    new Claim(ClaimTypes.Email, "admin@mywebsite.com")
};

var identity = new ClaimsIdentity(claims, Constants.AuthTypeSchemeName);
```

- Note that the Policy states that a claim with Dept Hr is needed. But when logging in we are not setting that. So we get an exception.

```
Error.
Acccess is denied for your request.
Request ID: 00-4556b0d2513868ee605a30fdfce68b02-ab7c2df613b46b56-00

Development Mode
Swapping to the Development environment displays detailed information about the error that occurred.

The Development environment shouldn't be enabled for deployed applications. It can result in displaying sensitive information from exceptions to end users. For local debugging, enable the Development environment by setting the ASPNETCORE_ENVIRONMENT environment variable to Development and restarting the app.
```

- So now when logging in, add one more claim as follows. **new Claim("Dept"., "Hr")**

```
var claims = new List<Claim> {
    new Claim(ClaimTypes.Name, "admin"),
    new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
    new Claim("Dept"., "Hr"),
};

var identity = new ClaimsIdentity(claims, Constants.AuthTypeSchemeName);
```

- Now logout and login again. If logout is not implimented yet, then Run the app, press F12 and delete the Auth cookie. Theis enables you to  login again.

- Now try to acces the Hr Page. 
- Note that we have added an access denied page as well.