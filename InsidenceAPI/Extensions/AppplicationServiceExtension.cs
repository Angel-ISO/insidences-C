using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.UnitOfWork;
using Dominio.Interfaces;

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
}