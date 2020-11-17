using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.Dom.Styles
{
    public struct BorderBox
    {
        public static BorderBox None => new BorderBox
        {
            Top = BorderStyle.None,
            Right = BorderStyle.None,
            Bottom = BorderStyle.None,
            Left = BorderStyle.None,
        };

        public BorderStyle Top { get; set; }

        public BorderStyle Right { get; set; }

        public BorderStyle Bottom { get; set; }

        public BorderStyle Left { get; set; }

        public BorderBox(BorderStyle top) : this(top, top, top, top)
        { }

        public BorderBox(BorderStyle top, BorderStyle right) : this(top, right, top, right)
        { }

        public BorderBox(BorderStyle top, BorderStyle right, BorderStyle bottom) : this(top, right, bottom, right)
        {}

        public BorderBox(BorderStyle top, BorderStyle right, BorderStyle bottom, BorderStyle left) : this()
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        public Box Box => new Box
        {
            Top = Top.Width,
            Right = Right.Width,
            Bottom = Bottom.Width,
            Left = Left.Width,
        };
    }
}
