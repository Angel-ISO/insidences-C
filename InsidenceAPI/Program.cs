using System.Reflection;
using AspNetCoreRateLimit;
using InsidenceAPI.Extensions;
using iText.Kernel.XMP.Options;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => {

    options.RespectBrowserAcceptHeader = true;
    options.ReturnHttpNotAcceptable=true;
}).AddXmlSerializerFormatters();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.AddAplicationService();
builder.Services.ConfigureRateLimiting();
builder.Services.ConfigureApiVersioning();

builder.Services.AddDbContext<IncidenceContext>(options =>
{
    string  connectionString = builder.Configuration.GetConnectionString("ConexHome");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseIpRateLimiting();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();