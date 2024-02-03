# Introduces Custom Requirement.

- This builds from the previous example.

- Add Remember Me bool to the user model
 
```cs
[Display(Name = "Remeber Me")]
public bool RememberMe { get; set; }
```

- Add **remember me** check box in the login UI. 
```cs
<div class="col-2">
    <input type="checkbox" asp-for="UserCreds.RememberMe" class="form-check-input" />
    <label class="form-check-label" asp-for="UserCreds.RememberMe"></label>
</div>
```

- Add Authentication Properties objects to SignInAsync method.

```cs

var authProperties = new AuthenticationProperties
{
    IsPersistent = UserCreds.RememberMe
};
// So now SignInAsync here is serializing the claimsPrincipal, encrypt it, and then 
// save that as a cookie and send that back in the response.
await HttpContext.SignInAsync(Constants.AuthTypeSchemeName, claimsPrincipal, authProperties);

```

- Finally adjust the **ExpireTimeSpan** so we can run the test.

```cs
cookieAuthenticationOptions.ExpireTimeSpan = TimeSpan.FromSeconds(120);
```

- Now, run, login. When logging in, first ensure the check box is unchecked. Then login. Donot click logout link, but close the full browser(not just the **tab**). Then browse once again to the same url. Observe that login page is shown again. Inspite of the fact that you have not explicitly logged out by clicking the logout link, you are logged out just because you closed the browser.

- Repeat now with check box is checked.

