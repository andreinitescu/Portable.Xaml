using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlPointTypeConverter : Portable.Xaml.ComponentModel.TypeConverter
    {
        private readonly PointTypeConverter _converter;

        public XamlPointTypeConverter()
        {
            _converter = new PointTypeConverter();
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
            var o = (Point) value;
            return $"{o.X}, {o.Y}";
        }
    }
}