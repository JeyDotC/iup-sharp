using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI
{
    public static class IupSizeExtensions
    {
        public static IupSize FullWidth(this IupSize size)
        {
            return new IupSize
            {
                Width = "FULL",
                Height = size.Height,
            };
        }

        public static IupSize FullHeight(this IupSize size)
        {
            return new IupSize
            {
                Width = size.Width,
                Height = "FULL",
            };
        }

        public static IupSize HalfWidth(this IupSize size)
        {
            return new IupSize
            {
                Width = "HALF",
                Height = size.Height,
            };
        }

        public static IupSize HalfHeight(this IupSize size)
        {
            return new IupSize
            {
                Width = size.Width,
                Height = "HALF",
            };
        }

        public static IupSize ThirdWidth(this IupSize size)
        {
            return new IupSize
            {
                Width = "THIRD",
                Height = size.Height,
            };
        }

        public static IupSize ThirdHeight(this IupSize size)
        {
            return new IupSize
            {
                Width = size.Width,
                Height = "THIRD",
            };
        }

        public static IupSize QuarterWidth(this IupSize size)
        {
            return new IupSize
            {
                Width = "QUARTER",
                Height = size.Height,
            };
        }

        public static IupSize QuarterHeight(this IupSize size)
        {
            return new IupSize
            {
                Width = size.Width,
                Height = "QUARTER",
            };
        }

        public static IupSize EighthWidth(this IupSize size)
        {
            return new IupSize
            {
                Width = "EIGHTH",
                Height = size.Height,
            };
        }

        public static IupSize EighthHeight(this IupSize size)
        {
            return new IupSize
            {
                Width = size.Width,
                Height = "EIGHTH",
            };
        }
    }
}
