using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XenWebViewSourceTypeConverter : TypeConverter
    {
        private readonly WebViewSourceTypeConverter _converter;

        public XenWebViewSourceTypeConverter()
        {
            _converter = new WebViewSourceTypeConverter();
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
            var o = (UrlWebViewSource) value;
            return o.Url;
        }
    }
}