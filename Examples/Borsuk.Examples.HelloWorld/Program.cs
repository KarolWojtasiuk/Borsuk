using System.Drawing;
using Borsuk.Rendering;
using Borsuk.Rendering.Sdl2;
using Borsuk.Windowing;
using Borsuk.Windowing.Sdl2;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddSdl2Windowing()
    .AddSdl2Rendering()
    .BuildServiceProvider();

var windowOptions = new WindowCreationOptions("Hello World!", new WindowSize(800, 600));
var window = services.GetRequiredService<IWindowProvider>().Create(windowOptions);
var renderer = services.GetRequiredService<IRendererProvider>().Create(window);

window.Show();
renderer.Clear(Color.Red);
renderer.Render();

await Task.Delay(TimeSpan.FromSeconds(1));