# Introduces Authorization Service(not Authentication).

- This builds from the previous example.

- In the _Layuout file, add the login status partial.

```html
<div class="mr-2">
    <partial name="_LoginStatusPartial" />
</div>
```

- Then the login status partial itself.

```cs
@if (User.Identity!.IsAuthenticated)
{
    <form method="post" class="form-inline" asp-page="/LoginLogout/Logout">
        Welcome @User.Identity.Name
        <button type="submit" class="ml-2 btn btn-link">Logout</button>
    </form>
}
else
{
    <a class="btn btn-link" asp-page="/LoginLogout/Login">Login</a>
}
```

- Finally we need to have the logout page, which logsout like this.

```cs
await HttpContext.SignOutAsync("MyCookieAuth");
```


