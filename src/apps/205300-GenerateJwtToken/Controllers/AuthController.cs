using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GenerateJwtToken.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration configuration;

    public AuthController(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    [HttpPost]
    public IActionResult Authenticate([FromBody]Credential credential)
    {
        // Verify the credential
        if (credential.UserName == "admin" && credential.Password == "123")
        {
            // Creating the security context
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                new Claim("Department", "HR"),
                new Claim("Admin", "true"),
                new Claim("Manager", "true"),
                new Claim("EmploymentDate", "2021-02-01")
            };

            var expiresAt = DateTime.UtcNow.AddMinutes(10);

            var token = CreateToken(claims, expiresAt);

            return Ok(new
            {
                access_token = token,
                expires_at = expiresAt
            });
        }

        ModelState.AddModelError("Unauthorized", "You are not authorized to access the endpoint.");
        return Unauthorized(ModelState);
    }

    private string CreateToken(IEnumerable<Claim> claims, DateTime expiresAt)
    {
        var secretKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey"));

        var jwt = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expiresAt,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256Signature));

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);
        
        return token;
    }
}

public class Credential
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}