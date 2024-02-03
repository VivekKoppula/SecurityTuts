# Asp.net core Web app with login page.

- This builds from the previous example.

- The reference is [project is here](https://github.com/AvtsVivek/webpacktuts/tree/main/code/600500-aspnetcore-webapp-webpack). 

- Now Add Authorization.

- So We add **[Authorize]** attribute to Index page. See Index.cshtml.cs file(IndexModel class)

- Also note the Program.cs file. Our login page is NOT in Account/Login. Its /LoginLogout/LogIn. So it needs to be explicitly set it. 

- That is because options.LoginPath default is **/Account/LogIn**

```cs
options.LoginPath = "/LoginLogout/LogIn";
```

- In the program.cs file, you can see
```cs
app.UseAuthentication();
app.UseAuthorization();
```
- Now if you comment out **app.UseAuthorization();** and run to access Index page, you get an exception. And the exception will clearly tell you what the problem is.

```
InvalidOperationException: Endpoint /Index contains authorization metadata, but a middleware was not found that supports authorization.
Configure your application startup by adding app.UseAuthorization() in the application startup code. If there are calls to app.UseRouting() and app.UseEndpoints(...), the call to app.UseAuthorization() must go between them.
```

- Also note that there is no **Authorization**(we are NOT talking about **Authentication**) Service configuration in the example. We will be adding that in the next example.

- 