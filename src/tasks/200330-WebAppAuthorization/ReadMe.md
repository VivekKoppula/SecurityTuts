# Asp.net core Web app with login page.

- This builds from the previous example.

- Now Add Authorization.

- So We add **[Authorize]** attribute to Index page. See Index.cshtml.cs file(IndexModel class)

- Also note the Program.cs file. Our login page is NOT in Account/Login. Its /LoginLogout/LogIn. So it needs to be explicitly set it. 

- That is because options.LoginPath default is **/Account/LogIn**

```cs
options.LoginPath = "/LoginLogout/LogIn";
```


