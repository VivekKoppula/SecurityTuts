# Session introduction.
- References:
  - [App State](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0)
  - asdf
- Here is how this app is created
  - Create a web as usual.
  - Then Add session middle ware.
    ```cs
    app.UseSession();
    ```
  - Also configure the session options
    ```cs
    builder.Services.AddDistributedMemoryCache();

    builder.Services.AddSession(options =>
    {
        options.Cookie.Name = ".AdventureWorks.Session";
        options.IdleTimeout = TimeSpan.FromSeconds(10);
        options.Cookie.IsEssential = true;
    });
    ```
  - Note 10 seconds in TimeSpan.FromSeconds(10);
  - After that time, the session will be cleared automatically.