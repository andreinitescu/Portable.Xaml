using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XenLayoutOptionsConverter : TypeConverter
    {
        private readonly LayoutOptionsConverter _converter;

        public XenLayoutOptionsConverter()
        {
            _converter = new LayoutOptionsConverter();
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
            var o = (LayoutOptions) value;
            return o.Alignment.ToString();
        }
    }
}
