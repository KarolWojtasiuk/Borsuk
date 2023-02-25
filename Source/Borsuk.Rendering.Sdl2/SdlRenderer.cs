using System.Drawing;
using Borsuk.Sdl;

namespace Borsuk.Rendering.Sdl2;

internal class SdlRenderer : IRenderer, ISdlObject
{
    public SdlRenderer(SdlHandle sdlHandle)
    {
        SdlHandle = sdlHandle;
    }

    public SdlHandle SdlHandle { get; }

    public void Render()
    {
        SDL_RenderPresent(SdlHandle);
    }

    public void Clear(Color color)
    {
        SDL_SetRenderDrawColor(SdlHandle, color.R, color.G, color.B, color.A);
        SDL_RenderClear(SdlHandle);
    }

    public void Dispose()
    {
        SDL_DestroyRenderer(SdlHandle);
    }
}