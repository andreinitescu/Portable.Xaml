using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlFontTypeConverter : Portable.Xaml.ComponentModel.TypeConverter
    {
        private readonly FontTypeConverter _converter;

        public XamlFontTypeConverter()
        {
            _converter = new FontTypeConverter();
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
            var o = (Font) value;
            var s = Math.Ceiling(o.FontSize);

            if (string.IsNullOrWhiteSpace(o.FontFamily) || o.FontSize == 0)
            {
                return string.Empty;
            }

            return $"{o.FontFamily}, {o.FontAttributes}, {s}";
        }
    }
}