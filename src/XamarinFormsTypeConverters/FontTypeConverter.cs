using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XenFontTypeConverter : TypeConverter
    {
        private readonly FontTypeConverter _converter;

        public XenFontTypeConverter()
        {
            _converter = new FontTypeConverter();
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
            var o = (Font) value;
            var s = Math.Round(o.FontSize, MidpointRounding.AwayFromZero);

            if (string.IsNullOrWhiteSpace(o.FontFamily) || o.FontSize == 0)
            {
                return string.Empty;
            }

            return $"{o.FontFamily}, {o.FontAttributes}, {s}";
        }
    }
}