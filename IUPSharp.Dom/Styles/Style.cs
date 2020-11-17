using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.Dom.Styles
{
    public class Style
    {

        public Style()
        {}

        public Style(Style style)
        {
            FontStyles = new FontStyles(style.FontStyles);
            Padding = style.Padding;
            Margin = style.Margin;
            Border = style.Border;
            Background = new PaintStyle(style.Background);
            Display = style.Display;
            Width = style.Width;
            Height = style.Height;
        }

        public FontStyles FontStyles { get; set; } = FontStyles.Default;

        public Box Padding { get; set; } = Box.None;

        public Box Margin { get; set; } = Box.None;

        public BorderBox Border { get; set; } = BorderBox.None;

        public PaintStyle Background { get; set; } = PaintStyle.None;

        public DisplayStyle Display { get; set; }

        public StyleValue<LengthHint> Width { get; set; }

        public StyleValue<LengthHint> Height { get; set; }
    }
}
