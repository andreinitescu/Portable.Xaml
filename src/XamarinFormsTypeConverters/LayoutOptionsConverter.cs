using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlLayoutOptionsConverter : Portable.Xaml.ComponentModel.TypeConverter
    {
        private readonly LayoutOptionsConverter _converter;

        public XamlLayoutOptionsConverter()
        {
            _converter = new LayoutOptionsConverter();
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
            var o = (LayoutOptions) value;

            if (o.Alignment == LayoutAlignment.Center)
            {
                return o.Expands ? "CenterAndExpand" : "Center";
            }

            if (o.Alignment == LayoutAlignment.End)
            {
                return o.Expands ? "EndAndExpand" : "End";
            }

            if (o.Alignment == LayoutAlignment.Fill)
            {
                return o.Expands ? "FillAndExpand" : "Fill";
            }

            if (o.Alignment == LayoutAlignment.Start)
            {
                return o.Expands ? "StartAndExpand" : "Start";
            }

            return string.Empty;
        }
    }
}
