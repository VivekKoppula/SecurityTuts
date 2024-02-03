# Jwt Auth

- Add **Authorize** attribute to the WeatherForecast

- Run the app and send a get request to 
```
https://localhost:7224/WeatherForecast 
```
- See the PostRequestToWeatherforeCastApi.http. You should get an exception.

```
System.InvalidOperationException: No authenticationScheme was specified, and there was no DefaultChallengeScheme found. The default schemes can be set using either AddAuthentication(string defaultScheme) or AddAuthentication(Action<AuthenticationOptions> configureOptions).
```
- Next Add the middle ware app.UseAuthentication(); just before Authorization middle ware

```cs
app.UseAuthentication();
app.UseAuthorization();
```

- Now repeate the get request. You get the same exception. This is because the handler is not configured. The handler is the object which will read the token. The token is passed on with the request via the header. 

- So the handler is configured as follows.

```cs
builder.Services.AddAuthentication(
    // We are configuring the Auth Scheme in a much granular level here.
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("SecretKey"))),
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            ClockSkew = TimeSpan.Zero
        };
    });
```

- Note that the SecretKey is read from the appSettings file.
- Now run the app, get the token by sending a post req to POST https://localhost:7224/Auth
- Next call the weatherforecast by sending a GET req to https://localhost:7224/WeatherForecast 
- The token must be set in the Authorization Header.
