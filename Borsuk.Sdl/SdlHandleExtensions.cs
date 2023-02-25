namespace Borsuk.Sdl;

public static class SdlHandleExtensions
{
    public static SdlHandle ToSdlHandle(this IntPtr handle, string methodName)
    {
        if (handle == IntPtr.Zero)
            throw new SdlException(methodName);
        
        return new SdlHandle(handle);
    }
}