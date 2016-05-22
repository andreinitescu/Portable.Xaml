using System;
using System.Linq;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamlColorTypeConverter : Portable.Xaml.ComponentModel.TypeConverter
    {
        private readonly ColorTypeConverter _converter;
        private static readonly string[] Colors;

        static XamlColorTypeConverter()
        {
            Colors = GetDefinedColors();
        }

        public XamlColorTypeConverter()
        {
            _converter = new ColorTypeConverter();
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
            if (Colors.Contains(value))
            {
                return value;
            }

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


        private static string[] GetDefinedColors()
        {
            var names = typeof (Color)
                .GetStaticFields()
                .Where(f => f.FieldType == typeof (Color))
                .Select(f => f.Name)
                .ToArray();

            return names;
        }
    }
}