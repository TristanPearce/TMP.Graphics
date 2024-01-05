﻿// See https://aka.ms/new-console-template for more information
using TMP.Graphics;
using TMP.Graphics.Win32.Window;

Console.WriteLine("Hello, World!");

Win32Window window = new Win32Window();
window.MessageHandlers.Add(new ConsoleLoggingWin32NativeWindowMessageHandler());
window.Show();

while (true)
{
    window.PumpEvents();
    Thread.Sleep(10);
}