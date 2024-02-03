# Web App calls and gets data from a secured Web Api using JWT tokens. 

- In this example, We will apply policy based authorization to JWT auth. 
- Configure Authorization service and middle ware
```cs
builder.Services.AddAuthorization(options => {
    options.AddPolicy("EnggTeamOnly",
        policy => policy.RequireClaim("EnggTeam"));
});

...
app.UseAuthentication();
app.UseAuthorization();
```

- So here we are defining a policy called EnggTeamOnly with requires a claim called EnggTeam.
- Next the weather forecast end point must be Auththorized with EnggTeamOnly policy.
```cs
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "EnggTeamOnly")] /// See here.
```
- Next we have to include the claims in the AuthController.cs
```cs
new Claim("EnggTeam", "true"),
```
- Now run and try to access the Engg page.
- 

