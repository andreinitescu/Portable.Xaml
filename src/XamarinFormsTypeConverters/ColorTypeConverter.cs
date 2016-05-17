using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XenColorTypeConverter : TypeConverter
    {
        private readonly ColorTypeConverter _converter;

        public XenColorTypeConverter()
        {
            _converter = new ColorTypeConverter();
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
            var o = (Color) value;

            if (o.A == -1 && o.R == -1 && o.G == -1 && o.B == -1)
            {
                return "Default";
            }

            if (o.A == 1)
            {
                return $"#{(int) (o.R*255):X2}{(int) (o.G*255):X2}{(int) (o.B*255):X2}";
            }

            return $"#{(int) (o.A*255):X2}{(int) (o.R*255):X2}{(int) (o.G*255):X2}{(int) (o.B*255):X2}";
        }
    }
}
