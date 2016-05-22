using System;
using System.Collections.Generic;
using Portable.Xaml.ComponentModel;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public static class TypeConverterRegistrar
    {
        static readonly Dictionary<Type, Type> Converters = new Dictionary<Type, Type>
        {
            //{ typeof(Double), typeof(XamarinFontSizeConverter) },
            //{ typeof(Uri), typeof(XamlUriTypeConverter) },

            { typeof(Button.ButtonContentLayout), typeof(XamlButtonContentTypeConverter) },
            { typeof(Color), typeof(XamlColorTypeConverter) },
            { typeof(FileImageSource), typeof(XamlFileImageSourceConverter) },
            { typeof(Font), typeof(XamlFontTypeConverter) },
            { typeof(GridLength), typeof(XamlGridLengthTypeConverter) },
            { typeof(ImageSource), typeof(XamlImageSourceConverter) },
            { typeof(Keyboard), typeof(XamlKeyboardTypeConverter) },
            { typeof(LayoutOptions), typeof(XamlLayoutOptionsConverter) },
            { typeof(Point), typeof(XamlPointTypeConverter) },
            { typeof(Rectangle), typeof(XamlRectangleTypeConverter) },
            { typeof(Thickness), typeof(XamlThicknessTypeConverter) },
            { typeof(Uri), typeof(XamlUriTypeConverter) },
            { typeof(WebViewSource), typeof(XamlWebViewSourceTypeConverter) },
        };


        public static void Initialize()
        {
            foreach (var converter in Converters)
            {
                TypeDescriptor.Register(converter.Key, converter.Value);
            }
        }
    }
}