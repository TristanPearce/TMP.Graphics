// See https://aka.ms/new-console-template for more information
using System.Numerics;
using TMP.Graphics;
using TMP.Graphics.Rendering;
using TMP.Graphics.Win32;
using TMP.Graphics.Win32.Window;

Console.WriteLine("Hello, World!");

Win32Window window = new Win32Window();
window.MessageHandlers.Add(new ConsoleLoggingWin32NativeWindowMessageHandler());
Win32RenderContext rc = new Win32RenderContext(window);

rc.Rendering += Rendering;

void Rendering(IRenderer2D renderer)
{
    Outline outline = new Outline()
    {
        Colour = new Colour() { Red = 255, Green = 255, Blue = 0 },
        Thickness = 2
    };
    renderer.Outline = outline;

    Ellipse ellipse = new Ellipse();
    ellipse.X = 200;
    ellipse.Y = 100;
    ellipse.Width = 100;
    ellipse.Height = 200;
    renderer.Draw(ellipse);

    Line line = new Line();
    line.Start = new Vector2(100, 100);
    line.End = new Vector2(200, 200);
    renderer.Draw(line);

    Rectangle rectangle = new Rectangle();
    rectangle.X = 0;
    rectangle.Y = 0;
    rectangle.Width = 100;
    rectangle.Height = 200;
    renderer.Draw(rectangle);

    renderer.Clear(new Colour() { Red = 255 });
}

window.Show();

while (true)
{
    window.PumpEvents();
    Thread.Sleep(10);
}