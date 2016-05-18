using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlUriTypeConverter : Portable.Xaml.ComponentModel.TypeConverter
    {
        private readonly UriTypeConverter _converter;

        public XamlUriTypeConverter()
        {
            _converter = new UriTypeConverter();
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
            return destinationType == typeof(string);
        }

        public override object ConvertTo(object value, Type destinationType)
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