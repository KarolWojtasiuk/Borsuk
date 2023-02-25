using Borsuk.Windowing;

namespace Borsuk.Rendering;

public interface IRendererProvider
{
    public IRenderer Create(IWindow window);
}