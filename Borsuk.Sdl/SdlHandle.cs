namespace Borsuk.Sdl;

public record SdlHandle
{
    public IntPtr Handle { get; }

    public SdlHandle(IntPtr handle)
    {
        if (handle == IntPtr.Zero)
            throw new ArgumentNullException(nameof(handle));

        Handle = handle;
    }
}