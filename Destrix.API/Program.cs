using Destrix.Core.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders",
    builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddApiVersioning(p =>
{
    p.DefaultApiVersion = new ApiVersion(1, 0);
    p.ReportApiVersions = true;
    p.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddVersionedApiExplorer(p =>
{
    p.GroupNameFormat = "'v'VVV";
    p.SubstituteApiVersionInUrl = true;
});


ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

var connectionDestrixPostgreSQL = configuration.GetConnectionString("DestrixPostgreSQL");

Destrix.Application.ServiceCollectionExtension.AddApplicationDependencies(builder.Services);

Destrix.Infra.Data.ServiceCollectionExtension.AddInfraDataDependencies(builder.Services, connectionDestrixPostgreSQL);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CacauDigital.CognitiveFacial.API", Version = "v1" });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("user", policy => policy.RequireClaim("Destrix", "user"));
    options.AddPolicy("admin", policy => policy.RequireClaim("Destrix", "admin"));
});

var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.JwtKey));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

var apiVersions = provider.ApiVersionDescriptions
                          .OrderByDescending(x => x.ApiVersion)
                          .ToList();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    foreach (var api in apiVersions)
        c.SwaggerEndpoint($"/swagger/{api.GroupName}/swagger.json", $"CacauDigital.CognitiveFacial.API {api.GroupName}");
});

app.UseCors("AllowAllHeaders");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
