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

    public IntVector2 Size
    {
        get
        {
            SDL_GetWindowSize(SdlHandle, out var width, out var height);
            return new IntVector2(width, height);
        }
        set => SDL_SetWindowSize(SdlHandle, value.X, value.Y);
    }

    public IntVector2 Position
    {
        get
        {
            SDL_GetWindowPosition(SdlHandle, out var x, out var y);
            return new IntVector2(x, y);
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

    public void ProcessEvents()
    {
        while (SDL_PollEvent(out var sdlEvent) != 0)
        {
            if (sdlEvent.type == SDL_EventType.SDL_WINDOWEVENT && sdlEvent.window.windowEvent == SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE)
                Dispose(); // TODO

            //TODO: handle events
        }
    }

    public void Dispose()
    {
        SDL_DestroyWindow(SdlHandle);
    }
}