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

    public Color DrawColor
    {
        get
        {
            SDL_GetRenderDrawColor(SdlHandle, out var r, out var g, out var b, out var a);
            return Color.FromArgb(a, r, g, b);
        }
        set => SDL_SetRenderDrawColor(SdlHandle, value.R, value.G, value.B, value.A);
    }

    public void Clear()
    {
        SDL_RenderClear(SdlHandle);
    }

    public void DrawPoint(IntVector2 position)
    {
        SDL_RenderDrawPoint(SdlHandle, position.X, position.Y);
    }

    public void DrawLine(IntVector2 from, IntVector2 to)
    {
        SDL_RenderDrawLine(SdlHandle, from.X, from.Y, to.X, to.Y);
    }

    public void Render()
    {
        SDL_RenderPresent(SdlHandle);
    }

    public void Dispose()
    {
        SDL_DestroyRenderer(SdlHandle);
    }
}