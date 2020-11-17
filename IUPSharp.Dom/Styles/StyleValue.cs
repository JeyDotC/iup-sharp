using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.Dom.Styles
{
    public struct StyleValue<TValue> where TValue : struct
    {
        public ValueKind ValueKind { get; set; }

        public TValue Value { get; set; }

        public static implicit operator StyleValue<TValue>(TValue value) => new StyleValue<TValue>
        {
            ValueKind = ValueKind.Value,
            Value = value
        };

        public static implicit operator StyleValue<TValue>(ValueKind valueKind) => new StyleValue<TValue>
        {
            ValueKind = valueKind,
            Value = default
        };
    }
}
