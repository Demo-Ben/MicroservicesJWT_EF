using ApiGateway.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Load Ocelot config
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// JWT Authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings["Key"]!))
            };
    });

builder.Services.AddAuthorization();

// Add MVC controllers (AuthController lives here)
builder.Services.AddControllers();

// Add Ocelot
builder.Services.AddOcelot();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
//await app.UseOcelot();

// MVC FIRST → AuthController works
app.MapControllers();

//If you put UseOcelot() before MapControllers(), your AuthController will NEVER run.
// Ocelot LAST → handles microservice routing
//await app.UseOcelot();

app.Run();

//404	Ocelot swallowed the route	AuthController not in Ocelot
//502	Ocelot forwarded request to itself	Remove self‑routing
//AuthController not working	Ocelot ran before MVC	Run MVC first


// Version with JwtAuth but no Swagger or MVC controllers (for testing Ocelot routing only)

//builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseAuthorization();

//await app.UseOcelot();
//app.MapControllers();

//app.Run();
