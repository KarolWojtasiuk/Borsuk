using Microsoft.Extensions.DependencyInjection;

namespace Borsuk.Windowing.Sdl2;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddSdl2Windowing(this IServiceCollection services)
    {
        return services.AddSingleton<IWindowProvider, SdlWindowProvider>();
    }
}