using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlButtonContentTypeConverter : Portable.Xaml.ComponentModel.TypeConverter
    {
        private readonly Button.ButtonContentTypeConverter _converter;

        public XamlButtonContentTypeConverter()
        {
            _converter = new Button.ButtonContentTypeConverter();
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
            var o = value as Button.ButtonContentLayout;
            if (o == null) return null;

            return $"{o.Position}, {o.Spacing}";
        }
    }
}
