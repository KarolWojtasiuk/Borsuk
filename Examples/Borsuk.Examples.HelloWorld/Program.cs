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
var window = services.GetRequiredService<IWindowProvider>().Create(windowOptions);
var renderer = services.GetRequiredService<IRendererProvider>().Create(window);

window.Show();

while (true)
{
    renderer.DrawColor = Color.Gold;
    renderer.Clear();

    // Triangle
    renderer.DrawColor = Color.Red;
    renderer.DrawLine(new IntVector2(100, 500), new IntVector2(300, 100));
    renderer.DrawLine(new IntVector2(500, 500), new IntVector2(300, 100));
    renderer.DrawLine(new IntVector2(100, 500), new IntVector2(500, 500));

    // Top
    renderer.DrawColor = Color.Black;
    foreach (var x in Enumerable.Range(295, 10))
    foreach (var y in Enumerable.Range(95, 10))
        renderer.DrawPoint(new IntVector2(x, y));

    renderer.Render();
    window.ProcessEvents();
}
