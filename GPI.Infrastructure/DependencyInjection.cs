using GPI.Infrastructure.Interfaces.Services;
using GPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        _ = services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}