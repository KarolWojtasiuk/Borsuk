namespace Borsuk.Windowing;

public interface IWindow : IDisposable
{
    public string Title { get; set; }
    public WindowSize Size { get; set; }
    public WindowPosition Position { get; set; }

    public void Show();
    public void Hide();

    public event EventHandler? Shown;
    public event EventHandler? Hidden;
}