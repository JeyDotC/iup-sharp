using System;
using System.Collections.Generic;
using System.Drawing;

namespace IUPSharp.Dom.Styles
{
    public class GradientSpec
    {
        private readonly IList<ColorStop> _colorStops = new List<ColorStop>();

        public GradientType Type { get; set; }

        public IEnumerable<ColorStop> ColorStops => _colorStops;

        public Point Start { get; set; }

        public Point End { get; set; }

        public float InnerRadius { get; set; }

        public float OuterRadius { get; set; }

        public GradientSpec AddColorStop(ColorStop colorStop)
        {
            _colorStops.Add(colorStop);
            return this;
        }

        public GradientSpec AddColorStop(float percent, Color color) => AddColorStop(new ColorStop(percent, color));

        public static GradientSpec Linear(Point start, Point end) => new GradientSpec
        {
            Type = GradientType.Linear,
            Start = start,
            End = end
        };

        public static GradientSpec Radial(Point start, float radius, Point end, float outerRadius) => new GradientSpec
        {
            Type = GradientType.Radial,
            Start = start,
            InnerRadius = radius,
            End = end,
            OuterRadius = outerRadius,
        };

        public GradientSpec() {}

        public GradientSpec(GradientSpec spec)
        {
            _colorStops = new List<ColorStop>(spec.ColorStops);
            Type = spec.Type;
            Start = spec.Start;
            End = spec.End;
            InnerRadius = spec.InnerRadius;
            OuterRadius = spec.OuterRadius;
        }
    }
}
