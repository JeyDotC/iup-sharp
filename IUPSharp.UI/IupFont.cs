using System;
using System.Linq;

namespace IUPSharp.UI
{
    public struct IupFont
    {
        public string FontFace { get; set; }

        public bool Bold { get; set; }

        public bool Italic { get; set; }

        public bool Underline { get; set; }

        public bool Strikeout { get; set; }

        public IupFontSize Size { get; set; }

        public override string ToString()
        {
            var styles = new string[]
            {
                Bold      ? nameof(Bold     ) : "",
                Italic    ? nameof(Italic   ) : "",
                Underline ? nameof(Underline) : "",
                Strikeout ? nameof(Strikeout) : ""
            }.Where(s => !string.IsNullOrEmpty(s));

            return $"{FontFace}, {(string.Join(' ', styles))} {Size}";
        }

        public static implicit operator IupFont(string iupFont)
        {
            if (string.IsNullOrWhiteSpace(iupFont))
            {
                return new IupFont();
            }

            var parts = iupFont.Split(',', System.StringSplitOptions.RemoveEmptyEntries);
            var fontFace = parts[0];
            var fontStylesAndSizes = parts[1].Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            var size = float.Parse(fontStylesAndSizes.Last());
            var styles = fontStylesAndSizes.SkipLast(1);

            return new IupFont
            {
                FontFace = fontFace,
                Size = new IupFontSize
                {
                    Size = Math.Abs(size),
                    Units = size < 0 ? IupFontUnits.Px : IupFontUnits.Pt,
                },
                Bold = styles.Contains(nameof(Bold)),
                Italic = styles.Contains(nameof(Italic)),
                Underline = styles.Contains(nameof(Underline)),
                Strikeout = styles.Contains(nameof(Strikeout)),
            };
        }
    }

    public struct IupFontSize
    {
        public float Size { get; set; }

        public IupFontUnits Units { get; set; }

        public override string ToString()
        {
            return (Units == IupFontUnits.Pt ? Size : -Size).ToString();
        }
    }

    public enum IupFontUnits
    {
        Pt,
        Px
    }
}