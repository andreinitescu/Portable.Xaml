using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlThicknessTypeConverter : TypeConverter
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

        [Obsolete("use ConvertFromInvariantString (string)")]
        public override object ConvertFrom(CultureInfo culture, object value)
        {
            return _converter.ConvertFromInvariantString(value as string);
        }

        [Obsolete("use ConvertFromInvariantString (string)")]
        public override object ConvertFrom(object o)
        {
            return _converter.ConvertFromInvariantString(o as string);
        }

        public bool CanConvertTo(Type destinationType)
        {
            return destinationType == typeof (string);
        }

        public object ConvertTo(object value, Type destinationType)
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