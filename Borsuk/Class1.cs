using Microsoft.Extensions.DependencyInjection;

namespace Borsuk;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddBorsuk(this IServiceCollection services)
    {
        return services;
    }
}