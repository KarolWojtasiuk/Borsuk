using Microsoft.Extensions.DependencyInjection;

namespace Borsuk.Rendering.Sdl2;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddSdl2Rendering(this IServiceCollection services)
    {
        return services.AddSingleton<IRendererProvider, SdlRendererProvider>();
    }
}