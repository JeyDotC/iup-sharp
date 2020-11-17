using System;
using System.Drawing;

namespace IUPSharp.Dom.Styles
{
    public struct ColorStop
    {
        public float Percent { get; }

        public Color Color { get; }

        public ColorStop(float percent, Color color): this()
        {
            Percent = percent;
            Color = color;
        }
    }
}
