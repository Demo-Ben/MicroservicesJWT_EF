using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderService.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient("PaymentService", c =>
{
    c.BaseAddress = new Uri("https://localhost:5002/");
});

builder.Services.AddHttpClient("InventoryService", c =>
{
    c.BaseAddress = new Uri("https://localhost:5003/");
});


builder.Services.AddHttpClient();

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

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// This scans the assembly where "Program" lives for any Mapping Profiles
builder.Services.AddAutoMapper(typeof(Program));



// Part II
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS is not needed if API Gateway is used, as the client will call API Gateway, not OrderService directly.
//app.UseCors(builder =>  //CORS must be placed after UseRouting() and before UseAuthentication().
//{
//    builder
//    .AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader();
//});

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
