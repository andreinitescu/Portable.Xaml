using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XenUriTypeConverter : TypeConverter
    {
        private readonly UriTypeConverter _converter;

        public XenUriTypeConverter()
        {
            _converter = new UriTypeConverter();
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
            return destinationType == typeof(string);
        }

        public object ConvertTo(object value, Type destinationType)
        {
            if (value is string)
            {
                return (string)value;
            }

            if (value is Uri)
            {
                return ((Uri) value).OriginalString;
            }

            return value.ToString();
        }
    }
}