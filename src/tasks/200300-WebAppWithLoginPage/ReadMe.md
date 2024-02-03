# Asp.net core Web app with login page.

- This a regular dotnet core web app.
- This can be generated from either VS 2022 or dotnet cli as follows.

```ps
dotnet new sln --name WebAppCookieAuth 

dotnet new webapp --name WebAppCookieAuth --framework net6.0

Copy-Item ./WebAppCookieAuth/* . -Recurse

# Now that we have copied all of the items inside of the folder, we can delete all of the items inside of it and the folder itself.
Remove-Item ./WebAppCookieAuth -Recurse

dotnet sln add WebAppCookieAuth.csproj
```

- Then add Add LoginLogout folder inside of Pages folder. 

- Then add Login.cshtml razor page.

- Update the _Layout page to include a login link in the UI

- Also add User class in Models folder.

- Then run the app, go to login page by clicking the login link in the home page.

- Type in the credentials and then click submit.

- 


