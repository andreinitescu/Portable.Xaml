using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlFileImageSourceConverter : Portable.Xaml.ComponentModel.TypeConverter
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
            return value as string;
        }
    }
}