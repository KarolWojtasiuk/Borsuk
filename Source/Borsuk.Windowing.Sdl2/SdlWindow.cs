using Borsuk.Sdl;

namespace Borsuk.Windowing.Sdl2;

internal class SdlWindow : IWindow, ISdlObject
{
    public SdlWindow(SdlHandle sdlHandle)
    {
        SdlHandle = sdlHandle;
    }

    public SdlHandle SdlHandle { get; }

    public string Title
    {
        get => SDL_GetWindowTitle(SdlHandle);
        set => SDL_SetWindowTitle(SdlHandle, value);
    }

    public WindowSize Size
    {
        get
        {
            SDL_GetWindowSize(SdlHandle, out var width, out var height);
            return new WindowSize(width, height);
        }
        set => SDL_SetWindowSize(SdlHandle, value.Width, value.Height);
    }

    public WindowPosition Position
    {
        get
        {
            SDL_GetWindowPosition(SdlHandle, out var x, out var y);
            return new WindowPosition(x, y);
        }
        set => SDL_SetWindowPosition(SdlHandle, value.X, value.Y);
    }

    public event EventHandler? Shown;
    public event EventHandler? Hidden;

    public void Show()
    {
        SDL_ShowWindow(SdlHandle);
        Shown?.Invoke(this, EventArgs.Empty);
    }

    public void Hide()
    {
        SDL_HideWindow(SdlHandle);
        Hidden?.Invoke(this, EventArgs.Empty);
    }

    public void Dispose()
    {
        SDL_DestroyWindow(SdlHandle);
    }
}