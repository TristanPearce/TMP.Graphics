using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TMP.Graphics.Rendering;

namespace TMP.Graphics.Win32.Renderer2D.Deferred
{
    internal abstract class DeferredCommand
    { }

    internal class DrawLineDeferredCommand : DeferredCommand
    {
        private Line _line;
        public DrawLineDeferredCommand(Line line)
        {
            _line = line;
        }

        public static explicit operator Line(DrawLineDeferredCommand command) 
        {
            return command._line;
        }
    }

    internal class DrawEllipseDeferredCommand : DeferredCommand
    {
        private Ellipse _ellipse;

        public DrawEllipseDeferredCommand(Ellipse ellipse)
        {
            _ellipse = ellipse;
        }
    }

    internal class DrawRectangleDeferredCommand : DeferredCommand
    {
        private Rectangle _rectangle;

        public DrawRectangleDeferredCommand(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }
    }

    internal class DrawImageDeferredCommand : DeferredCommand
    {
        private Image _image;
        public DrawImageDeferredCommand(Image image)
        {
            _image = image;
        }
    }

    internal class DrawPolygonDeferredCommand : DeferredCommand
    {
        private Polygon _polygon;

        public DrawPolygonDeferredCommand(Polygon polygon)
        {
            _polygon = polygon;
        }
    }

    internal class SetOutlineDeferredCommand : DeferredCommand
    {
        private Outline _outline;

        public SetOutlineDeferredCommand(Outline outline)
        {
            _outline = outline;
        }

        public static explicit operator Outline(SetOutlineDeferredCommand command)
        {
            return command._outline;
        }
    }

    internal class SetFillDeferredCommand : DeferredCommand
    {
        private Fill _fill;

        public SetFillDeferredCommand(Fill fill)
        {
            _fill = fill;
        }
    }
}
