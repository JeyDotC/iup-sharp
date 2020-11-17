using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace IUPSharp.UI
{
    public abstract class IupControl : IupObject
    {
        internal IupControl(IntPtr handle): base(handle) { }

        protected Color GetColor(string attribute)
        {
            var colorParts = (Get(attribute) ?? "0 0 0 255").Split(' ').Select(int.Parse).ToArray();

            return Color.FromArgb(colorParts[3], colorParts[0], colorParts[1], colorParts[2]);
        }

        protected void SetColor(string attribute, Color value)
        {
            Set(attribute, $"{value.R} {value.G} {value.B} {value.A}");
        }

        protected bool GetBoolean(string attribute) => Get(attribute) == "YES";
        protected void SetBoolean(string attribute, bool value) => Set(attribute, value ? "YES" : "NO");

        protected TEnum GetEnum<TEnum>(string attribute)
            where TEnum : Enum => (TEnum)Enum.Parse(typeof(TEnum), Get(attribute), true);

        protected void SetEnum<TEnum>(string attribute, TEnum value)
            where TEnum : Enum => Set(attribute, value.ToString("G").ToUpper());


        protected Size GetSize(string attribute)
        {
            var naturalSize = Get(attribute);
            if (string.IsNullOrEmpty(naturalSize))
            {
                return new Size();
            }

            var parts = naturalSize.Split('x');
            var width = int.Parse(parts[0] ?? "0");
            var height = int.Parse(parts[1] ?? "0");

            return new Size(width, height);
        }
        protected void SetSize(string attribute, Size value) => Set(attribute, $"{value.Width}x{value.Height}");


        protected Point GetPosition(string attribute)
        {
            var naturalSize = Get(attribute);
            if (string.IsNullOrEmpty(naturalSize))
            {
                return new Point();
            }

            var parts = naturalSize.Split('x');
            var x = int.Parse(parts[0] ?? "0");
            var y = int.Parse(parts[1] ?? "0");

            return new Point(x, y);
        }
        protected void SetPosition(string attribute, Point value) => Set(attribute, $"{value.X}x{value.Y}");

        public bool Active
        {
            get => GetBoolean("ACTIVE");
            set => SetBoolean("ACTIVE", value);
        }

        public Color BgColor
        {
            get => GetColor("BGCOLOR");
            set => SetColor("BGCOLOR", value);
        }

        public Color FgColor
        {
            get => GetColor("FGCOLOR");
            set => SetColor("FGCOLOR", value);
        }

        public IupFont Font
        {
            get => Get("FONT");
            set => Set("FONT", value.ToString());
        }

        public string Theme { get => Get("THEME"); set => Set("THEME", value); }

        public bool Visible
        {
            get => GetBoolean("VISIBLE");
            set => SetBoolean("VISIBLE", value);
        }

        // Sizing

        public IupExpandMode Expand
        {
            get => GetEnum<IupExpandMode>("EXPAND");
            set => SetEnum("EXPAND", value);
        }

        public IupSize MaxSize { get => Get("MAXSIZE"); set => Set("MAXSIZE", value); }

        public IupSize MinSize { get => Get("MINSIZE"); set => Set("MINSIZE", value); }

        public Size NaturalSize
        {
            get => GetSize("NATURALSIZE");
            set => SetSize("NATURALSIZE", value);
        }

        public Size RasterSize
        {
            get => GetSize("RASTERSIZE");
            set => SetSize("RASTERSIZE", value);
        }

        public IupSize Size
        {
            get => Get("SIZE");
            set => Set("SIZE", value);
        }

        // Positioning

        public IupFloatingMode Floating
        {
            get => GetEnum<IupFloatingMode>("FLOATING");
            set => SetEnum("FLOATING", value);
        }

        public Point Position
        {
            get => GetPosition("POSITION");
            set => SetPosition("POSITION", value);
        }

        public Point ScreenPosition => GetPosition("SCREENPOSITION");

        // Identity

        public string Tip { get => Get("TIP"); set => Set("TIP", value); }


        // All elements with an associated text.
        public string Title { get => Get("TITLE"); set => Set("TITLE", value); }

        // Internal stuff.
        //public string Wid { get => Get("WID"); }

    }
}
