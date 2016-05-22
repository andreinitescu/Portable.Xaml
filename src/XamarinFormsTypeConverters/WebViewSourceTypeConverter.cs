using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlWebViewSourceTypeConverter : Portable.Xaml.ComponentModel.TypeConverter
    {
        private readonly WebViewSourceTypeConverter _converter;

        public XamlWebViewSourceTypeConverter()
        {
            _converter = new WebViewSourceTypeConverter();
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
            var o = (UrlWebViewSource) value;
            return o.Url;
        }
    }
}