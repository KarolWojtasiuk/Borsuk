namespace Borsuk.Windowing;

public interface IWindow : IDisposable
{
    public string Title { get; set; }
    public IntVector2 Size { get; set; }
    public IntVector2 Position { get; set; }

    public void Show();
    public void Hide();
    public void ProcessEvents();

    public event EventHandler? Shown;
    public event EventHandler? Hidden;
}