// using System;
// using BookamApi.Data;
// using BookamApi.Interfaces;
// using BookamApi.Models;
// using BookamApi.Repositories;
// using BookamApi.Services;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.IdentityModel.Tokens;
// using Microsoft.OpenApi.Models;
// using Newtonsoft.Json;

// public class Program
// {
//     public static async Task Main(string[] args)
//     {
//         var builder = WebApplication.CreateBuilder(args);

//         // Add services to the container.
//         builder.Services.AddControllers();
//         builder.Services.AddEndpointsApiExplorer();
//         builder.Services.AddSwaggerGen();

//         builder.Services.AddControllers()
//         .AddNewtonsoftJson(options =>
//         {
//             options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//         });

//         builder.Services.AddSwaggerGen(option =>
//         {
//             option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
//             option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//             {
//                 In = ParameterLocation.Header,
//                 Description = "Please enter a valid token",
//                 Name = "Authorization",
//                 Type = SecuritySchemeType.Http,
//                 BearerFormat = "JWT",
//                 Scheme = "Bearer"
//             });
//             option.AddSecurityRequirement(new OpenApiSecurityRequirement
//             {
//                 {
//                     new OpenApiSecurityScheme
//                     {
//                         Reference = new OpenApiReference
//                         {
//                             Type=ReferenceType.SecurityScheme,
//                             Id="Bearer"
//                         }
//                     },
//                     new string[]{}
//                 }
//             });
//         });

//         // ✅ In-Memory DB for testing instead of PostgreSQL
//         builder.Services.AddDbContext<AppDbContext>(options =>
//         {
//             options.UseInMemoryDatabase("TestDb");
//         });

//         // Email service
//         builder.Services.AddTransient<IEmailService, EmailService>();

//         // Connect interface services here
//         builder.Services.AddScoped<ITokenService, TokenService>();
//         builder.Services.AddScoped<IBusRepository, BusRepository>();
//         builder.Services.AddScoped<IRouteRepository, RouteRepository>();

//         builder.Services.AddIdentity<User, IdentityRole>(options =>
//         {
//             options.Password.RequireDigit = true;
//             options.Password.RequireLowercase = true;
//             options.Password.RequireUppercase = true;
//             options.Password.RequireNonAlphanumeric = true;
//             options.Password.RequiredLength = 8;
//         })
//         .AddEntityFrameworkStores<AppDbContext>()
//         .AddDefaultTokenProviders();

//         builder.Services.AddAuthentication(options =>
//         {
//             options.DefaultAuthenticateScheme =
//             options.DefaultChallengeScheme =
//             options.DefaultForbidScheme =
//             options.DefaultScheme =
//             options.DefaultSignInScheme =
//             options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
//         })
//         .AddJwtBearer(options =>
//         {
//             options.TokenValidationParameters = new TokenValidationParameters
//             {
//                 ValidateIssuer = true,
//                 ValidIssuer = builder.Configuration["JWT:Issuer"],
//                 ValidateAudience = true,
//                 ValidAudience = builder.Configuration["JWT:Audience"],
//                 ValidateIssuerSigningKey = true,
//                 IssuerSigningKey = new SymmetricSecurityKey(
//                     System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
//                 )
//             };
//         });

//         var app = builder.Build();

//         // ✅ Seed roles and test user
//         using (var scope = app.Services.CreateScope())
//         {
//             var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//             var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

//             string[] roles = new[] { "USER", "ADMIN" };
//             foreach (var role in roles)
//             {
//                 if (!await roleManager.RoleExistsAsync(role))
//                 {
//                     await roleManager.CreateAsync(new IdentityRole(role));
//                 }
//             }

            
//         }

//         // Configure the HTTP request pipeline
//         if (app.Environment.IsDevelopment())
//         {
//             app.UseSwagger();
//             app.UseSwaggerUI();
//         }

//         app.UseHttpsRedirection();
//         app.UseAuthentication();
//         app.UseAuthorization();
//         app.MapControllers();

//         await app.RunAsync(); // Async version of app.Run()
//     }
// }








using System;
using BookamApi.Data;
using BookamApi.Interfaces;
using BookamApi.Models;
using BookamApi.Repositories;
using BookamApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

// builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Testing"));



builder.Services.AddDbContext<AppDbContext>(options => 
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") + 
    ";Pooling=true;Minimum Pool Size=1;Maximum Pool Size=20;Keepalive=30;Timeout=15;Command Timeout=60;",
     npgsqlOptionsAction: sqlOptions => 
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorCodesToAdd: null);
        sqlOptions.CommandTimeout(60);
        });
});
//email service
builder.Services.AddTransient<IEmailService, EmailService>();

//connect interface services here
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IBusRepository, BusRepository>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<AppDbContext>( )
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme = 
    options.DefaultScheme =
    options.DefaultSignInScheme = 
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
#pragma warning disable CS8604 // Possible null reference argument.
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        )
    };
#pragma warning restore CS8604 // Possible null reference argument.
}
);

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//     string[] roles = new[] { "USER", "ADMIN" }; // Add more if needed

//     foreach (var role in roles)
//     {
//         if (!await roleManager.RoleExistsAsync(role))
//         {
//             await roleManager.CreateAsync(new IdentityRole(role));
//         }
//     }
// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
