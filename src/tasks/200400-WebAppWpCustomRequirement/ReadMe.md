# Introduces Custom Requirement.

- This builds from the previous example.

- Impliment EmployeeConfirmationRequirement and its handler

- Add Policy
```cs
authorizationOptions.AddPolicy("ConfirmedEnggOnly", policy => policy
.RequireClaim("Dept", "Engg")
// .RequireClaim("")
.Requirements.Add(new EnggProbationRequirement(3)));
```

- Register Authorization Service with 

```cs
builder.Services.AddSingleton<IAuthorizationHandler, EnggProbationRequirementHandler>();
```

- Add Claims when we are logging in and creating the security context.
```cs
new Claim("Dept", "Engg"),
// new Claim("Manager", "true"),
new Claim("EmploymentDate", "2022-02-01")
```

- Add the engg page.

- Now run, login and then access the page.