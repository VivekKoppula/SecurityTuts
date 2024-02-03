# Web App Aspdotnet core identity.

- This builds on the previous example. That example has a register page to register user.
- This example adds a login and logout pages, so users can login to the app and then can logout as well.
- Add login page to the Account folder.
- The login page basically uses a signin manager object to login the user.
- Add login partial in the shared folder.
- Add logout page in the Account folder
- Add the login partial link in the Layout page.

  ```html
  <div class="mr-2">
      <partial name="_LoginStatusPartial" />
  </div>
  ```
- Finally adjust the **ExpireTimeSpan** so we can run the test.

```cs
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromSeconds(120);
});
```

- Now, run, login. When logging in, first ensure the check box is unchecked. Then login. Donot click logout link, but close the full browser(not just the **tab**). Then browse once again to the same url. Observe that login page is shown again. Inspite of the fact that you have not explicitly logged out by clicking the logout link, you are logged out just because you closed the browser.

- Repeat now with check box is checked.
