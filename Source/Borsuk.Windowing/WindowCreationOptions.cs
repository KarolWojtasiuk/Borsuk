namespace Borsuk.Windowing;

public record WindowCreationOptions(string Title, WindowSize Size, Vector2<int>? Position = null);