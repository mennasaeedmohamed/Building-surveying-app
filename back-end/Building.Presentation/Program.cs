//using AutoMapper;
//using Building.Context.Context;
//using Building.Repositories;
//using Building.Services;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;

//namespace Building.Presentation
//{
//    public class Program
//    {
//        public static async Task Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.

//            builder.Services.AddScoped<IBuildingService, BuildingService>();
//            builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();

//            builder.Services.AddDbContext<BuildingDbContext>(options =>
//            {
//                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
//            });

//            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
//            {
//                // Configure identity options if needed
//            })
//            .AddEntityFrameworkStores<BuildingDbContext>()
//            .AddDefaultTokenProviders();

//            builder.Services.AddAuthentication(options =>
//            {
//                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            }).AddJwtBearer(options =>
//            {
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
//                    ValidateIssuerSigningKey = true,
//                    ValidateIssuer = false,
//                    ValidateAudience = false,
//                };
//            });

//            builder.Services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

//                // Define the OAuth2.0 scheme that's in use (i.e., Implicit, Password, Application and AccessCode)
//                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//                {
//                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
//                    Name = "Authorization",
//                    In = ParameterLocation.Header,
//                    Type = SecuritySchemeType.ApiKey,
//                    Scheme = "Bearer"
//                });

//                c.AddSecurityRequirement(new OpenApiSecurityRequirement
//                {
//                    {
//                        new OpenApiSecurityScheme
//                        {
//                            Reference = new OpenApiReference
//                            {
//                                Type = ReferenceType.SecurityScheme,
//                                Id = "Bearer"
//                            },
//                            Scheme = "oauth2",
//                            Name = "Bearer",
//                            In = ParameterLocation.Header
//                        },
//                        new string[] {}
//                    }
//                });
//            });

//            builder.Services.AddAutoMapper(op =>
//            {
//                op.AddProfile(new MapperProfile());
//            });

//            builder.Services.AddControllers();

//            var app = builder.Build();

//            // Seed roles
//            using (var serviceScope = app.Services.CreateScope())
//            {
//                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//                await RoleInitializer.InitializeAsync(roleManager);
//            }

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();
//            app.UseAuthentication();
//            app.UseAuthorization();
//            app.MapControllers();

//            app.Run();
//        }
//    }


//    public static class RoleInitializer
//    {
//        public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager)
//        {

//            string[] roleNames = { "Admin", "User" };
//            foreach (var roleName in roleNames)
//            {
//                if (!await roleManager.RoleExistsAsync(roleName))
//                {
//                    await roleManager.CreateAsync(new IdentityRole(roleName));
//                }
//            }
//        }
//    }
//}

using AutoMapper;
using Building.Context.Context;
using Building.Repositories;
using Building.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

namespace Building.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IBuildingService, BuildingService>();
            builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();

            builder.Services.AddDbContext<BuildingDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Configure identity options if needed
            })
            .AddEntityFrameworkStores<BuildingDbContext>()
            .AddDefaultTokenProviders();


            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

               
            });

            builder.Services.AddAutoMapper(typeof(MapperProfile)); // Register the mapping profile

            // Configure CORS policy to allow requests from localhost:3000
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            builder.Services.AddControllers();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowReactApp");
            // Uncomment if authentication is added
            // app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
