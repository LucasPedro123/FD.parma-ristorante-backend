using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Services;
using RestaurantAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
<<<<<<< HEAD:src/RestaurantApi/Program.cs
=======
using RestaurantAPI.Middlewares;
using RestaurantAPI.Repositories;
using RestaurantAPI.Services;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
>>>>>>> dev:Program.cs

builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<MenuService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var key = builder.Configuration["Jwt:Key"]
    ?? throw new Exception("JWT Key não encontrada no appsettings.json");

var issuer = builder.Configuration["Jwt:Issuer"]
    ?? throw new Exception("JWT Issuer não encontrado no appsettings.json");

var audience = builder.Configuration["Jwt:Audience"]
    ?? throw new Exception("JWT Audience não encontrado no appsettings.json");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});

builder.Services.AddAuthorization();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services
builder.Services.AddScoped<CardapioService>();
builder.Services.AddScoped<ReservaService>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

<<<<<<< HEAD:src/RestaurantApi/Program.cs
app.MapControllers();
=======

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.WebRootPath, "menu-images")),
    RequestPath = "/menu-images"
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// pipeline
>>>>>>> dev:Program.cs
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();

