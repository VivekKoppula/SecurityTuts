# Introduces Custom Requirement.

- This builds from the previous example.

- Add expiration to cookie as follows. Also demos SlidingExpiration concept.
 
```cs
cookieAuthenticationOptions.ExpireTimeSpan = TimeSpan.FromSeconds(10);
cookieAuthenticationOptions.SlidingExpiration = false;
```

- Now login, refresh and observe. Also change SlidingExpiration to true/false and then observe again.

```cs
cookieAuthenticationOptions.SlidingExpiration = false;
```

- If the Sliding Expiration is set to fals as shown above, then no matter how many times you refresh, it will expire after the set time, in this case 10 seconds(TimeSpan.FromSeconds(10)). 

- But if you set that to true, then when ever you refresh within that window(10 seconds in this case), the expiry time will again be pushed to the new 10 seconds. Try it. 

