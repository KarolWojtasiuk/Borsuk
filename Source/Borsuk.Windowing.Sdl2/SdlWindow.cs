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

    public Vector2<int> Size
    {
        get
        {
            SDL_GetWindowSize(SdlHandle, out var width, out var height);
            return new Vector2<int>(width, height);
        }
        set => SDL_SetWindowSize(SdlHandle, value.X, value.Y);
    }

    public Vector2<int> Position
    {
        get
        {
            SDL_GetWindowPosition(SdlHandle, out var x, out var y);
            return new Vector2<int>(x, y);
        }
        set => SDL_SetWindowPosition(SdlHandle, value.X, value.Y);
    }

    public event EventHandler? Shown;
    public event EventHandler? Hidden;
    public event EventHandler? Closing;

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

    public void ProcessEvents()
    {
        while (SDL_PollEvent(out var sdlEvent) != 0)
        {
            if (sdlEvent.type == SDL_EventType.SDL_WINDOWEVENT && sdlEvent.window.windowEvent == SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE)
                Dispose();

            //TODO: handle events
        }
    }

    public void Dispose()
    {
        Closing?.Invoke(this, EventArgs.Empty);
        SDL_DestroyWindow(SdlHandle);
    }
}