using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IUPSharp.Dom.Styles
{
    public class FontStyles
    {
        public static FontStyles Default { get; } = new FontStyles {
            FontSize = 12,
            FontColor = Color.Black,
            FontFamily = "Arial",
        };

        public string FontFamily { get; set; }

        public int FontSize { get; set; }

        public PaintStyle FontColor { get; set; }

        public FontStyles() { }

        public FontStyles(FontStyles font)
        {
            FontFamily = font.FontFamily;
            FontColor = new PaintStyle(font.FontColor);
            FontSize = font.FontSize;
        }
    }
}
