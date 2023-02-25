using System.Drawing;

namespace Borsuk.Rendering;

public interface IRenderer : IDisposable
{
    public void Render();
    public void Clear(Color color);
}