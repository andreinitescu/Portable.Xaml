using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlFileImageSourceConverter : TypeConverter
    {
        private readonly FileImageSourceConverter _converter;

        public XamlFileImageSourceConverter()
        {
            _converter = new FileImageSourceConverter();
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
            return value as string;
        }
    }
}