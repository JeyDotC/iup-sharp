using System;
namespace IUPSharp.Dom.Styles
{
    public struct LengthHint
    {
        public float Value { get; }

        public MeasureUnit Unit { get; }

        public LengthHint(float value, MeasureUnit unit = MeasureUnit.Pixels)
        {
            Value = value;
            Unit = unit;
        }

        public int GetDrawValue(int relativeTo = 0)
            => Unit switch {
                MeasureUnit.Pixels => (int)Value,
                MeasureUnit.Percent => (int)MathF.Ceiling((Value / 100) * relativeTo),
                _ => (int)Value,
            };

        public static implicit operator LengthHint(float value) => new LengthHint(value);

        public static implicit operator LengthHint(MeasureUnit unit) => new LengthHint(0, unit);

        public static LengthHint operator +(LengthHint lengthHint, float value) => new LengthHint(lengthHint.Value + value, lengthHint.Unit);

        public static LengthHint operator -(LengthHint lengthHint, float value) => new LengthHint(lengthHint.Value - value, lengthHint.Unit);
    }
}
