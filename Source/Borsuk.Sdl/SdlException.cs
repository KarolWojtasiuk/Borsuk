namespace Borsuk.Sdl;

public class SdlException : Exception
{
    public SdlException(string methodName)
        : base($"{methodName}: {SDL_GetError()}")
    {
    }
}