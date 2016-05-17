using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlGridLengthTypeConverter : TypeConverter
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
            return _converter.CanConvertFrom(destinationType);
        }

        public object ConvertTo(object value, Type destinationType)
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