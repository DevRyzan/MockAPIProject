using Application.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
namespace Persistence;

public static class PersistenceServiceDIs
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                           IConfiguration configuration)
    {
        
        services.AddScoped<IObjectRepository<Domain.Models.Object>, ObjectRepository>();
        return services;
    }
}
