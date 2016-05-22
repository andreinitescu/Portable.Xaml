using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlThicknessTypeConverter : Portable.Xaml.ComponentModel.TypeConverter
    {
        private readonly ThicknessTypeConverter _converter;

        public XamlThicknessTypeConverter()
        {
            _converter = new ThicknessTypeConverter();
        }

        public override bool CanConvertFrom(Type sourceType)
        {
            return _converter.CanConvertFrom(sourceType);
        }

        public override object ConvertFrom(object o)
        {
            return _converter.ConvertFromInvariantString(o as string);
        }

        public override bool CanConvertTo(Type destinationType)
        {
            return destinationType == typeof (string);
        }

        public override object ConvertTo(object value, Type destinationType)
        {
            var o = (Thickness) value;
            var b = o.Bottom;
            var l = o.Left;
            var r = o.Right;
            var t = o.Top;

            if (b == l && b == r && b == t)
            {
                return b.ToString();
            }

            if (b == t && l == r)
            {
                return $"{l},{b}";
            }

            return $"{l},{t},{r},{b}";
        }
    }
}