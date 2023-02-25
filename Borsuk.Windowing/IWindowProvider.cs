namespace Borsuk.Windowing;

public interface IWindowProvider
{
    IWindow Create(WindowCreationOptions options);
}