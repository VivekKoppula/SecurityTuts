## Web App Aspdotnet core identity.

- Adds more info during registration of a new user.

## The changes for this exercise are as follows.
- Student class
```cs
public class Student : IdentityUser
{
    public int YearEnrolled { get; set; } 
    public string RollNumber { get; set; } = default!;
}
```

- In App db context, we have to derive from the generic IdentityDbContext.

```cs
public class AppDbContext : IdentityDbContext<Student>
{ ... }
```

```cs
public class AppDbContext : IdentityDbContext<Student>
{ ... }
```

- In the RegisterViewModel.cs we need to add the two fileds, Rollumber and YearEnrolled.

- In the confirm Email Model class, we need to update the UserManager type with **UserManager<Student>**
  - Similarly in LoginModel, LogoutModel, RegisterModel, RegisterSuccessModel, and also in EmailService

- In the RegisterModels class, the StudentCreation should be as follows.
```cs
var user = new Student
{
    Email = RegisterViewModel.Email,
    UserName = RegisterViewModel.Email,
    RollNumber = RegisterViewModel.RollNumber,
    YearEnrolled = RegisterViewModel.YearEnrolled
};
```

- Also in the Register view Register.cshtml, need to add the two fileds.
- In Program.cs, we need to the following.
```cs
builder.Services.AddIdentity<Student, IdentityRole>(){}
```