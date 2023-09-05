using System.Reflection;
using System.Text;
using AspNetCoreRateLimit;
using InsidenceAPI.Extensions;
using InsidenceAPI.Helpers;
using iText.Kernel.XMP.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => {

    options.RespectBrowserAcceptHeader = true;
    options.ReturnHttpNotAcceptable=true;
}).AddXmlSerializerFormatters();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.AddAplicationService();
builder.Services.ConfigureRateLimiting();
builder.Services.ConfigureApiVersioning();



var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>{
    opt.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateAudience = false,
        ValidateIssuer = false
    };
});


builder.Services.AddAuthorization(opts =>{
    opts.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddRequirements(new GlobalVerbRoleRequirement())
        .Build();
});




builder.Services.AddDbContext<IncidenceContext>(options =>
{
    string  connectionString = builder.Configuration.GetConnectionString("ConexNew");
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