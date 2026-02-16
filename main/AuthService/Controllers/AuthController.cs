using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.Data;
using AuthService.DTOs;
using AuthService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
	private readonly AuthDbContext _db;
	private readonly IConfiguration _config;

	public AuthController(AuthDbContext db, IConfiguration config)
	{
		_db = db;
		_config = config;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterRequest request)
	{
		if (await _db.Users.AnyAsync(x => x.Username == request.Username))
			return BadRequest("User already exists");

		var user = new User
		{
			Username = request.Username,
			PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
		};

		_db.Users.Add(user);
		await _db.SaveChangesAsync();

		return Ok("User registered Successfully.");
	}

	[HttpPost("token")]
	public async Task<IActionResult> GetToken(LoginRequest request)
	{
		// get user based on users object from db
		var user = await _db.Users.FirstOrDefaultAsync(x => x.Username == request.Username);

		// check user object's password match request password
		if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
			return Unauthorized("Invalid credentials");

		var jwt = _config.GetSection("Jwt");
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.Username),
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
		};

		var token = new JwtSecurityToken(
			issuer: jwt["Issuer"],
			audience: jwt["Audience"],
			claims: claims,
			expires: DateTime.UtcNow.AddMinutes(double.Parse(jwt["ExpiresMinutes"]!)),
			signingCredentials: creds);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return Ok(new { token = tokenString });

        //return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
	}
}
