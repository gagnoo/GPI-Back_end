using System.Text;
using GPI.Presentation.BackgroundServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GPI.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        _ = services.AddSignalR();

        _ = services.AddControllers();
        _ = AddAuthorization(services, configuration);
        _ = services.AddAuthorization();
        _ = AddCors(services);

        _ = services.AddHostedService<UpdateCompanyPricesBackgroundService>();

        return services;
    }

    private static IServiceCollection AddCors(IServiceCollection services)
    {
        return services.AddCors(cors =>
        {
            cors.AddPolicy("Default", corsPolicyBuilder =>
            {
                corsPolicyBuilder.WithOrigins("http://localhost:4200")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }

    private static IServiceCollection AddAuthorization(
        IServiceCollection services,
        IConfiguration configuration)
    {
        string issuer = configuration["JwtSettings:Issuer"]!;
        string audience = configuration["JwtSettings:Audience"]!;
        string key = configuration["JwtSettings:Key"]!;

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>
            {
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

        return services;
    }
}