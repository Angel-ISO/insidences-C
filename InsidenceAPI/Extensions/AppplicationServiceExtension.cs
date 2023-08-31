using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Aplicacion.UnitOfWork;
using AspNetCoreRateLimit;
using Dominio;
using Dominio.Interfaces;
using InsidenceAPI.Helpers;
using InsidenceAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;
using Segurity.SegurityToken;

namespace InsidenceAPI.Extensions;

public static class ApplicationServiceExtension
{
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
               builder.AllowAnyOrigin()    //WithOrigins("https://domini.com")
               .AllowAnyMethod()           //WithMethods(*GET", "POST", "PUT", "DELETE")
               .AllowAnyHeader());         //WithHeaders(*accept*, "content-type")
        });  

         public static void AddAplicationService(this IServiceCollection services)
     {
        // services.AddScoped<IMoviesInterface, MovieRepository>();
        // services.AddScoped<IGenreInterface, GenreRepository>();
        // services.AddScoped<IDirectorInterface, DirectorRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(typeof(ApplicationServiceExtension));
        services.AddScoped<IJwtGenerator,JwtGenerator>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IUserService, UserService>();
     }


 public static void ConfigureRateLimiting(this IServiceCollection services)
    {
   services.AddMemoryCache();
     services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
     services.AddInMemoryRateLimiting();
     services.Configure<IpRateLimitOptions>(options =>{
      
       options.EnableEndpointRateLimiting = true;
       options.StackBlockedRequests = false;
       options.HttpStatusCode = 429;
       options.RealIpHeader = "localhost";
       options.GeneralRules = new List<RateLimitRule> 
         {
           new RateLimitRule
           {
             Endpoint = "*",
             Period  ="10s",
             Limit = 2
           }
         };
     });
    }

    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
     services.AddApiVersioning (Options => {
       

      Options.DefaultApiVersion = new ApiVersion(1, 0);
            Options.AssumeDefaultVersionWhenUnspecified = true;
            //options.ApiVersionReader = new QueryStringApiVersionReader("ver");
            Options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("ver"),
                new HeaderApiVersionReader("X-Version")
            );
            Options.ReportApiVersions = true;

        });
    }


    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        //Configuration from AppSettings
        services.Configure<JWT>(configuration.GetSection("JWT"));

        //Adding Athentication - JWT
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                };
            });
    }
}