using Borsuk.Sdl;
using Borsuk.Windowing;

namespace Borsuk.Rendering.Sdl2;

internal class SdlRendererProvider : IRendererProvider
{
    public IRenderer Create(IWindow window)
    {
        if (window is not ISdlObject sdlWindow)
            throw new NotSupportedException($"{nameof(SdlRenderer)} can only be used with SDL window");

        var handle = SDL_CreateRenderer(sdlWindow.SdlHandle, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED)
            .ToSdlHandle(nameof(SDL_CreateRenderer));

        return new SdlRenderer(handle);
    }
}