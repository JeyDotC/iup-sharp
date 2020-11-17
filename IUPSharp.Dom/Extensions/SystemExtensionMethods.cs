using IUPSharp.Dom.Styles;

namespace System
{
    public static class SystemExtensionMethods
    {
        public static LengthHint Px(this float value) => new LengthHint(value, MeasureUnit.Pixels);

        public static LengthHint Percent(this float value) => new LengthHint(value, MeasureUnit.Percent);
    }
}
