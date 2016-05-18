using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlRectangleTypeConverter : Portable.Xaml.ComponentModel.TypeConverter
    {
        private readonly RectangleTypeConverter _converter;

        public XamlRectangleTypeConverter()
        {
            _converter = new RectangleTypeConverter();
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
            var o = (Rectangle) value;
            return $"{o.X}, {o.Y}, {o.Width}, {o.Height}";
        }
    }
}