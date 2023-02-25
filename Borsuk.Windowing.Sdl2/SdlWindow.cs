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
        get => SDL_GetWindowTitle(SdlHandle.Handle);
        set => SDL_SetWindowTitle(SdlHandle.Handle, value);
    }

    public WindowSize Size
    {
        get
        {
            SDL_GetWindowSize(SdlHandle.Handle, out var width, out var height);
            return new WindowSize(width, height);
        }
        set => SDL_SetWindowSize(SdlHandle.Handle, value.Width, value.Height);
    }

    public WindowPosition Position
    {
        get
        {
            SDL_GetWindowPosition(SdlHandle.Handle, out var x, out var y);
            return new WindowPosition(x, y);
        }
        set => SDL_SetWindowPosition(SdlHandle.Handle, value.X, value.Y);
    }

    public event EventHandler? Shown;
    public event EventHandler? Hidden;

    public void Show()
    {
        SDL_ShowWindow(SdlHandle.Handle);
        Shown?.Invoke(this, EventArgs.Empty);
    }

    public void Hide()
    {
        SDL_HideWindow(SdlHandle.Handle);
        Hidden?.Invoke(this, EventArgs.Empty);
    }

    public void Dispose()
    {
        SDL_DestroyWindow(SdlHandle.Handle);
    }
}