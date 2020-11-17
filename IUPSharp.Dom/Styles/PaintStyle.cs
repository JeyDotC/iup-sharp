using System;
using System.Drawing;

namespace IUPSharp.Dom.Styles
{
    public class PaintStyle
    {
        public static PaintStyle None => new PaintStyle { Type = PaintStyleType.None };

        public PaintStyleType Type { get; set; } = PaintStyleType.Solid;

        public Color Color { get; set; }

        public GradientSpec Gradient { get; set; } = new GradientSpec();

        public static implicit operator PaintStyle(Color color) => new PaintStyle
        {
            Type = PaintStyleType.Solid,
            Color = color,
        };

        public static implicit operator PaintStyle(GradientSpec gradient) => new PaintStyle
        {
            Type = PaintStyleType.Gradient,
            Gradient = gradient,
        };

        public PaintStyle() { }

        public PaintStyle(PaintStyle paint)
        {
            Type = paint.Type;
            Color = paint.Color;
            Gradient = new GradientSpec(paint.Gradient);
        }
    }
}
