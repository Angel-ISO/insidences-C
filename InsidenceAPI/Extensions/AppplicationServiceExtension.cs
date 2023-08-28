using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.UnitOfWork;
using AspNetCoreRateLimit;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

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
        Options.ApiVersionReader = new QueryStringApiVersionReader("ver");

     });
    }

}