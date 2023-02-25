namespace Borsuk.Windowing;

public interface IWindow : IDisposable
{
    public string Title { get; set; }
    public Vector2<int> Size { get; set; }
    public Vector2<int> Position { get; set; }

    public void Show();
    public void Hide();
    public void ProcessEvents();

    public event EventHandler? Shown;
    public event EventHandler? Hidden;
    public event EventHandler? Closing;
}