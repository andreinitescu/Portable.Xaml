using System;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlGridLengthTypeConverter : Portable.Xaml.ComponentModel.TypeConverter
    {
        private readonly GridLengthTypeConverter _converter;

        public XamlGridLengthTypeConverter()
        {
            _converter = new GridLengthTypeConverter();
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
            return _converter.CanConvertFrom(destinationType);
        }

        public override object ConvertTo(object value, Type destinationType)
        {
            var gl = (GridLength) value;

            if (gl.GridUnitType == GridUnitType.Auto)
            {
                return "Auto";
            }

            if (gl.GridUnitType == GridUnitType.Star)
            {
                if (gl.Value == 1)
                {
                    return "*";
                }

                return $"{gl.Value}, *";
            }

            return gl.Value.ToString();
        }
    }
}