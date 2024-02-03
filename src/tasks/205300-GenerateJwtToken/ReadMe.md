# Introduction to Json tokens.

- Create a regular Web Api.
- Then add packages.

```ps
dotnet add package System.IdentityModel.Tokens.Jwt 
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

- Then add a Auth Controller. AuthController.cs
- Run the GetTokenPostRequest.http rest client file. Rest client needs to be installed in vs code.

- Once you get the token, you can decode it. See the image.