using System.Drawing;
using Borsuk;
using Borsuk.Rendering;
using Borsuk.Rendering.Sdl2;
using Borsuk.Windowing;
using Borsuk.Windowing.Sdl2;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddSdl2Windowing()
    .AddSdl2Rendering()
    .BuildServiceProvider();

var windowOptions = new WindowCreationOptions("Hello World!", new WindowSize(600, 600));
using var window = services.GetRequiredService<IWindowProvider>().Create(windowOptions);
using var renderer = services.GetRequiredService<IRendererProvider>().Create(window);

var isRunning = true;
window.Closing += (_, _) => isRunning = false;

window.Show();

while (isRunning)
{
    renderer.DrawColor = Color.Gold;
    renderer.Clear();

    // Triangle
    renderer.DrawColor = Color.Red;
    renderer.DrawLine(new Vector2<int>(100, 500), new Vector2<int>(300, 100));
    renderer.DrawLine(new Vector2<int>(500, 500), new Vector2<int>(300, 100));
    renderer.DrawLine(new Vector2<int>(100, 500), new Vector2<int>(500, 500));

    // Top
    renderer.DrawColor = Color.Black;
    foreach (var x in Enumerable.Range(295, 10))
    foreach (var y in Enumerable.Range(95, 10))
        renderer.DrawPoint(new Vector2<int>(x, y));

    renderer.Render();
    window.ProcessEvents();
}
