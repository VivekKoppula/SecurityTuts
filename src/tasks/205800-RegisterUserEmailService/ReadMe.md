# Web App Aspdotnet core identity.

- This is same as the previous example, but this email sending logic is moved ot an email serviece.

- Note also in the Program.cs file, the email service is registered. 

```cs
builder.Services.AddScoped<IEmailService, EmailService>();
```