# Web App calls and gets data from a secured Web Api.

- The web api is secured. The end point in this case is https://localhost:7038/WeatherForecast
- The controller for this is ./../../apps/20350-WebAppCallSecureApi/SecureApi/Controllers/WeatherForecastController.cs
- Note **[Authorize]** attribute on the WeatherForecastController class.
- Also note the AddAuthentication in the Programm.cs file.

```cs
builder.Services.AddAuthentication(...)
    .AddJwtBearer(...);
```

- So a jwtoken is need for Authorization. This is obtained by calling the Auth end point.
- So this is what the Engg page in the Web app does.
- Also note that the cookied based authorization within the web app is commented out. The purpose of this example is to demonistrate the secured communication between web app and api. But not with-in the web app. So the cooked based auth within the web app is commented out.
- Note here that each time the Engg page is loaded/refreshed, the token is first fetched by calling the Auth endpoint and then the WeatherForecast data is fetched.
- So instead of getting the token each time, can the token be re-used for the rest of the session? This will be done in a subsequent example.
- 