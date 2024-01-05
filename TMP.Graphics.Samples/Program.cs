// See https://aka.ms/new-console-template for more information
using System.Numerics;
using TMP.Graphics;
using TMP.Graphics.Rendering;
using TMP.Graphics.Win32.Renderer2D.Deferred;
using TMP.Graphics.Win32.Renderer2D.Immediate;
using TMP.Graphics.Win32.Window;

Console.WriteLine("Hello, World!");

Win32Window window = new Win32Window();
window.MessageHandlers.Add(new ConsoleLoggingWin32NativeWindowMessageHandler());

//Win32ImmediateModeRenderer2D renderer = new Win32ImmediateModeRenderer2D(window);

//renderer.OnPaint += () => 
//{
//    Line line = new Line();
//    line.Start = new Vector2(100, 100);
//    line.End = new Vector2(200, 200);
//    renderer.Draw(line);

//    Line line2 = new Line();
//    line2.Start = new Vector2(100, 200);
//    line2.End = new Vector2(200, 100);
//    renderer.Draw(line2);
//};

Win32DeferredRenderer2D renderer2D = new Win32DeferredRenderer2D(window);

window.Show();

while (true)
{
    Outline outline = new Outline()
    {
        Colour = new Colour() { Red = 255 },
        Thickness = 2
    };
    renderer2D.Outline = outline; 

    Line line = new Line();
    line.Start = new Vector2(100, 100);
    line.End = new Vector2(200, 200);
    renderer2D.Draw(line);

    window.PumpEvents();
    Thread.Sleep(10);
}