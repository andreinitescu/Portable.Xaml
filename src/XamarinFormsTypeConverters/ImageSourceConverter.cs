using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlImageSourceConverter : Portable.Xaml.ComponentModel.TypeConverter
    {
        private readonly ImageSourceConverter _converter;

        public XamlImageSourceConverter()
        {
            _converter = new ImageSourceConverter();
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
                return (string) value;
            }

            if (value is UriImageSource)
            {
                return ((UriImageSource) value).Uri.AbsoluteUri;
            }

            return value.ToString();
        }
    }
}