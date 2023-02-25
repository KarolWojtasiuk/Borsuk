using System.Drawing;

namespace Borsuk.Rendering;

public interface IRenderer : IDisposable
{
    public Color DrawColor { get; set; }
    public void Clear();
    public void DrawPoint(IntVector2 position);
    public void DrawLine(IntVector2 from, IntVector2 to);
    public void Render();
}