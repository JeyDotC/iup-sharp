using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI
{
    public struct IupSize
    {
        public string Width { get; set; }

        public string Height { get; set; }

        public static implicit operator string(IupSize iupSize) => iupSize.ToString();
        public static implicit operator IupSize(string sizeString)
        {
            var parts = (sizeString ?? "0x0").Split('x');
            return new IupSize
            {
                Width = parts[0],
                Height = parts[1],
            };
        }

        public override string ToString()
        {
            return $"{Width}x{Height}";
        }

        public static IupSize Full => new IupSize
        {
            Width = "FULL",
            Height = "FULL",
        };

        public static IupSize Half => new IupSize
        {
            Width = "HALF",
            Height = "HALF",
        };


        public static IupSize Third => new IupSize
        {
            Width = "THIRD",
            Height = "THIRD",
        };

        public static IupSize Quarter => new IupSize
        {
            Width = "QUARTER",
            Height = "QUARTER",
        };

        public static IupSize Eighth => new IupSize
        {
            Width = "EIGHTH",
            Height = "EIGHTH",
        };

    }
}
