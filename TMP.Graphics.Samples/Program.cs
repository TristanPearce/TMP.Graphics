// See https://aka.ms/new-console-template for more information
using System.Numerics;
using TMP.Graphics;
using TMP.Graphics.Rendering2D;
using TMP.Graphics.Win32;
using TMP.Graphics.Win32.Window;

Console.WriteLine("Hello, World!");

Win32Window window = new Win32Window();
window.MessageHandlers.Add(new ConsoleLoggingWin32NativeWindowMessageHandler());
Win32RenderContext rc = new Win32RenderContext(window) { PreferredBackend = TMP.Graphics.Win32.Renderer2D.Win32RenderingBackend.GdiPlus };

Win32Window window2 = new Win32Window();
Win32RenderContext rc2 = new Win32RenderContext(window2) { PreferredBackend = TMP.Graphics.Win32.Renderer2D.Win32RenderingBackend.GdiPlus };

float value = 0;

rc.Rendering += Rendering;
rc2.Rendering += Rendering;

void Rendering(RenderingArguments args)
{
    IRenderer2D renderer = args.Renderer;
    IGraphicsFactory factory = args.GraphicsFactory;

    renderer.Fill = new Fill() 
    { 
        Colour = new Colour() { Red = 255 } 
    };
    Outline outline = new Outline()
    {
        Colour = new Colour() { Red = 255, Green = 255, Blue = 0 },
        Thickness = 2
    };
    renderer.Outline = outline;

    IEllipse ellipse = factory.CreateEllipse();
    ellipse.X = 200;
    ellipse.Y = 100;
    ellipse.RadiusX = 100;
    ellipse.RadiusY = 200;
    renderer.Draw(ellipse);

    ILine line = factory.CreateLine();
    line.StartX = 100;
    line.StartY = 100;
    line.EndX = 100;
    line.EndY = 100;
    renderer.Draw(line);

    IRectangle rectangle = factory.CreateRectangle();
    rectangle.X = 0;
    rectangle.Y = 0;
    rectangle.Width = 100;
    rectangle.Height = 200;
    renderer.Draw(rectangle);

    renderer.Outline = new Outline()
    {
        Colour = new Colour() { Red = 255, Blue = 255 },
        Thickness = 10
    };
    renderer.Fill = new Fill() { Colour = new Colour() { Green = 255 } };
    IPolygon poly = new Polygon(
        new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(100, 100),
            new Vector2(200, MathF.Sin(value) * 100f),
            new Vector2(100, 200)
        });
    renderer.Draw(poly);
}

window.Show();
window2.Show();

while (true)
{
    value = (value + 0.01f);
    rc.Refresh();
    rc2.Refresh();
    window.PumpEvents();
    window2.PumpEvents();
    Thread.Sleep(10);
}