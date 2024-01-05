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

        public static explicit operator Line(DrawLineDeferredCommand command) => command._line;
    }

    internal class DrawEllipseDeferredCommand : DeferredCommand
    {
        private Ellipse _ellipse;

        public DrawEllipseDeferredCommand(Ellipse ellipse)
        {
            _ellipse = ellipse;
        }

        public static explicit operator Ellipse(DrawEllipseDeferredCommand command) => command._ellipse;
    }

    internal class DrawRectangleDeferredCommand : DeferredCommand
    {
        private Rectangle _rectangle;

        public DrawRectangleDeferredCommand(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public static explicit operator Rectangle(DrawRectangleDeferredCommand command) => command._rectangle;
    }

    internal class DrawImageDeferredCommand : DeferredCommand
    {
        private Image _image;
        public DrawImageDeferredCommand(Image image)
        {
            _image = image;
        }

        public static explicit operator Image(DrawImageDeferredCommand command) => command._image;
    }

    internal class DrawPolygonDeferredCommand : DeferredCommand
    {
        private Polygon _polygon;

        public DrawPolygonDeferredCommand(Polygon polygon)
        {
            _polygon = polygon;
        }

        public static explicit operator Polygon(DrawPolygonDeferredCommand command) => command._polygon;
    }

    internal class SetOutlineDeferredCommand : DeferredCommand
    {
        private Outline _outline;

        public SetOutlineDeferredCommand(Outline outline)
        {
            _outline = outline;
        }

        public static explicit operator Outline(SetOutlineDeferredCommand command) => command._outline;
    }

    internal class SetFillDeferredCommand : DeferredCommand
    {
        private Fill _fill;

        public SetFillDeferredCommand(Fill fill)
        {
            _fill = fill;
        }

        public static explicit operator Fill(SetFillDeferredCommand command) => command._fill;
    }
}
