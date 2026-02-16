using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiGateway.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class AuthController : ControllerBase
//{
//    private readonly IConfiguration _config;

//    public AuthController(IConfiguration config)
//    {
//        _config = config;
//    }

//    [HttpPost("token")]
//    public IActionResult GetToken([FromBody] LoginRequest request)
//    {
//        // Demo only – replace with real user validation
//        if (request.Username != "admin" || request.Password != "password")
//            return Unauthorized();

//        var jwtSection = _config.GetSection("Jwt");
//        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]!));
//        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//        var claims = new[]
//        {
//            new Claim(JwtRegisteredClaimNames.Sub, request.Username),
//            new Claim(ClaimTypes.Role, "User")
//        };

//        var token = new JwtSecurityToken(
//            issuer: jwtSection["Issuer"],
//            audience: jwtSection["Audience"],
//            claims: claims,
//            expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSection["ExpiresMinutes"]!)),
//            signingCredentials: creds);

//        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

//        return Ok(new { token = tokenString });
//    }
//}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
