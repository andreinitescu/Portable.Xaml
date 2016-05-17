using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlFontSizeConverter : TypeConverter
    {
        private readonly FontSizeConverter _converter;

        public XamlFontSizeConverter()
        {
            _converter = new FontSizeConverter();
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
            var o = (double) value;
            var fs = Math.Round(o, MidpointRounding.AwayFromZero);
            return fs.ToString();
        }
    }
}