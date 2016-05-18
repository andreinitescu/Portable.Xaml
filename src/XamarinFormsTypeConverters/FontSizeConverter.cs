using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlFontSizeConverter : Portable.Xaml.ComponentModel.TypeConverter
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
            var o = (double) value;
            var fs = Math.Round(o, MidpointRounding.AwayFromZero);
            return fs.ToString();
        }
    }
}