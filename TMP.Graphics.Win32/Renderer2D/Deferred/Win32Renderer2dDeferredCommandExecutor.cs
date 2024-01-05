using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMP.Graphics.Rendering;
using static Vanara.PInvoke.Gdi32;
using Vanara.PInvoke;

namespace TMP.Graphics.Win32.Renderer2D.Deferred
{
    internal class Win32Renderer2dDeferredCommandExecutor
    {

        private HBRUSH _hbrush;
        private Fill _fill;
        public Fill Fill
        {
            get => _fill;
            set
            {
                DeleteObject(_hbrush);
                var colorRef = new COLORREF(value.Colour.Red, value.Colour.Green, value.Colour.Blue);
                _hbrush = CreateSolidBrush(colorRef);
                _ = SelectObject(HDC, _hbrush);

                _fill = value;
            }
        }

        private HPEN _hpen;
        private Outline _outline;
        public Outline Outline
        {
            get => _outline;
            set
            {
                DeleteObject(_hpen);
                var colorRef = new COLORREF(value.Colour.Red, value.Colour.Green, value.Colour.Blue);
                _hpen = CreatePen((uint)PenStyle.PS_SOLID, (int)value.Thickness, colorRef);  // Red pen
                _ = SelectObject(HDC, _hpen);

                _outline = value;
            }
        }

        public HDC HDC { get; set; }

        public Win32Renderer2dDeferredCommandExecutor()
        {
            Fill = new Fill();
            Outline = new Outline();
        }

        public void Execute(IEnumerable<DeferredCommand> commands)
        {
            foreach (var command in commands)
            {
                if (command is DrawLineDeferredCommand line)
                    Draw((Line)line);
                else if (command is SetOutlineDeferredCommand outline)
                    Outline = (Outline)outline;
            }
        }

        private void Draw(Line line)
        {
            MoveToEx(HDC, (int)line.Start.X, (int)line.Start.Y, out POINT p);  // Move to starting point
            LineTo(HDC, (int)line.End.X, (int)line.End.Y);           // Draw a line to ending 
        }
    }
}
