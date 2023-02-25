using Borsuk.Sdl;

namespace Borsuk.Windowing.Sdl2;

internal class SdlWindowProvider : IWindowProvider
{
    public IWindow Create(WindowCreationOptions options)
    {
        var handle = SDL_CreateWindow(
                options.Title,
                options.Position?.X ?? SDL_WINDOWPOS_UNDEFINED,
                options.Position?.Y ?? SDL_WINDOWPOS_UNDEFINED,
                options.Size.Width,
                options.Size.Height,
                SDL_WindowFlags.SDL_WINDOW_HIDDEN)
            .ToSdlHandle(nameof(SDL_CreateWindow));

        return new SdlWindow(handle);
    }
}