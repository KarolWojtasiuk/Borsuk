using System.Drawing;

namespace Borsuk.Rendering;

public interface IRenderer : IDisposable
{
    public Color DrawColor { get; set; }
    public void Clear();
    public void DrawPoint(Vector2<int> position);
    public void DrawLine(Vector2<int> from, Vector2<int> to);
    public void Render();
}