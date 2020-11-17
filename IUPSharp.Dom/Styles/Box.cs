using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IUPSharp.Dom.Styles
{
    public struct Box
    {
        public static Box None => new Box
        {
            Top = 0f.Px(),
            Right = 0f.Px(),
            Bottom = 0f.Px(),
            Left = 0f.Px(),
        };

        public StyleValue<LengthHint> Top { get; set; }

        public StyleValue<LengthHint> Right { get; set; }

        public StyleValue<LengthHint> Bottom { get; set; }

        public StyleValue<LengthHint> Left { get; set; }

        public Box(LengthHint top) : this(top, top, top, top)
        { }

        public Box(LengthHint top, LengthHint right) : this(top, right, top, right)
        { }

        public Box(LengthHint top, LengthHint right, LengthHint bottom) : this(top, right, bottom, right)
        { }

        public Box(LengthHint top, LengthHint right, LengthHint bottom, LengthHint left) : this()
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        public Point GetDrawPosition(Rectangle relativeTo)
            => new Point
            {
                X = Left.Value.GetDrawValue(relativeTo.Width),
                Y = Top.Value.GetDrawValue(relativeTo.Height)
            } + (Size)relativeTo.Location;

        public Size GetDrawSize(Size relativeTo = new Size())
            => new Size
            {
                Height = Top.Value.GetDrawValue(relativeTo.Height) + Bottom.Value.GetDrawValue(relativeTo.Height),
                Width = Left.Value.GetDrawValue(relativeTo.Width) + Right.Value.GetDrawValue(relativeTo.Width),
            } + relativeTo;
    }
}
